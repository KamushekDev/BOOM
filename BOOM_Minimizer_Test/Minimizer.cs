using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BOOM_Minimizer_Test
{
    public class Minimizer : IDisposable
    {
        Random rand = new Random();

        private int secondsForCDSearch = 30;
        private bool multyExpanding = false;

        public List<string> True { get; set; }
        public List<string> False { get; set; }
        public TernaryTree ImplicantBuffer { get; set; }

        public List<string> ExpansionBuffer { get; set; }

        private Form1 mainForm;

        public int Length { get; set; }

        public void Dispose()
        {
            ImplicantBuffer.Dispose();
        }

        private void ReadFunction(string path)
        {
            int length = 0;
            string[] lines = File.ReadAllLines(path);
            for (int i = 4; i < lines.Length; i++)
            {
                if (length != 0 && length != lines[i].Length - 2)
                    throw new ArgumentException("Ошибка во входных данных.");
                else
                    length = lines[i].Length - 2;
                if (lines[i][0] == '0')
                    False.Add(lines[i].Substring(2));
                else if (lines[i][0] == '1')
                    True.Add(lines[i].Substring(2));
            }
            Length = length;
        }

        private bool IntersectFalse(string input)
        {
            for (int i = 0; i < False.Count; i++)
            {
                bool intersect = true;
                for (int k = 0; k < Length; k++)
                {
                    if (input[k] == '-')
                        continue;
                    if (input[k] != False[i][k])
                    {
                        intersect = false;
                        break;
                    }
                }
                if (intersect)
                    return true;
            }
            return false;
        }

        private void ReduceTrue(List<string> trueReduced, string implicant)
        {
            for (int i = 0; i < trueReduced.Count; i++)
                for (int k = 0; k < implicant.Length; k++)
                {
                    if (implicant[k] != '-' && implicant[k] != trueReduced[i][k])
                        break;
                    if (k == implicant.Length - 1)
                        trueReduced.RemoveAt(i--);
                }
        }

        private void CD_Search()
        {
            long iteration = 0, ellapsedIterations = 0, lastChangeIteration = 0, implicantsCount = 0;
            DateTime startTime = DateTime.Now;
            while (true)
            {
                if (ellapsedIterations == long.MaxValue || iteration == long.MaxValue || (DateTime.Now - startTime).TotalSeconds > secondsForCDSearch)
                    break;
                iteration++; ellapsedIterations++;
                CD_SearchOnce();
                if (ImplicantBuffer.Count != implicantsCount)
                {
                    lastChangeIteration = iteration;
                    ellapsedIterations = 0;
                    implicantsCount = ImplicantBuffer.Count;
                    iteration = 0;
                }
                if (ellapsedIterations / 3 > lastChangeIteration)
                    break;
            }
            void CD_SearchOnce()
            {
                long[,] varFrequences = new long[2, Length];
                string t = new string(Enumerable.Repeat('-', Length).ToArray());///текущая импликанта

                List<string> trueReduced = True.ToList();///сокращённый истинный набор

                do
                {
                    t = new string(Enumerable.Repeat('-', Length).ToArray());
                    do
                    {
                        if (!t.Contains('-'))
                            t = new string(Enumerable.Repeat('-', Length).ToArray());
                        t = MostFrequenceVariable();

                    } while (IntersectFalse(t));
                    ReduceTrue(trueReduced, t);
                    if (ImplicantBuffer.Add(t))
                        ExpansionBuffer.Add(t);
                } while (trueReduced.Count > 0);
                //todo вернуть H (сгенерированные импликанты)

                string MergeTerms(string first, string second)
                {
                    if (first.Length != second.Length)
                        throw new ArgumentException("Строки разной длины.");
                    StringBuilder sb = new StringBuilder("");
                    for (int i = 0; i < first.Length; i++)
                    {
                        if (first[i] == '-' && second[i] == '-')
                            sb.Append('-');
                        else if ((first[i] == '0' && second[i] == '-') || (first[i] == '-' && second[i] == '0') || (first[i] == '0' && second[i] == '0'))
                            sb.Append('0');
                        else if ((first[i] == '1' && second[i] == '-') || (first[i] == '-' && second[i] == '1') || (first[i] == '1' && second[i] == '1'))
                            sb.Append('1');
                        else
                            throw new ArgumentException("Входные строки не соответствуют требованию");
                    }
                    return sb.ToString();
                }

                string MostFrequenceVariable()
                {
                    long max = -1;
                    int countMax = 0;
                    for (int i = 0; i < 2; i++)
                        for (int k = 0; k < Length; k++)
                            varFrequences[i, k] = 0;
                    ///Составление массива частоты вхождений переменных
                    for (int i = 0; i < Length; i++)
                        for (int k = 0; k < trueReduced.Count; k++)
                        {
                            if (t[i] == '-')
                                if (trueReduced[k][i] == '0')
                                {
                                    varFrequences[0, i]++;
                                    if (varFrequences[0, i] > max)
                                    {
                                        max = varFrequences[0, i];
                                        countMax = 1;
                                    }
                                    else if (varFrequences[0, i] == max)
                                        countMax++;

                                }
                                else if (trueReduced[k][i] == '1')
                                {
                                    varFrequences[1, i]++;
                                    if (varFrequences[1, i] > max)
                                    {
                                        max = varFrequences[1, i];
                                        countMax = 1;
                                    }
                                    else if (varFrequences[1, i] == max)
                                        countMax++;
                                }
                        }

                    ///обработка массива частоты вхождений переменных
                    List<string> mostFrequencesVariables = new List<string>(countMax); //Набор импликант
                    StringBuilder sb = new StringBuilder(new string(Enumerable.Repeat('-', Length).ToArray()));
                    int countImplicants = 0;
                    bool mutation = (rand.Next(0, 100) > 96);
                    if (mutation)
                    {
                        while (true)
                        {
                            int start = rand.Next(Length);
                            if (varFrequences[1, start] > 0)
                            {
                                sb[start] = '1';
                                string implicant = MergeTerms(t, sb.ToString());
                                if (!IntersectFalse(implicant))
                                    countImplicants++;
                                mostFrequencesVariables.Add(implicant);
                                sb[start] = '-';
                                break;
                            }
                            else if (varFrequences[0, start] > 0)
                            {
                                sb[start] = '0';
                                string implicant = MergeTerms(t, sb.ToString());
                                if (!IntersectFalse(implicant))
                                    countImplicants++;
                                mostFrequencesVariables.Add(implicant);
                                sb[start] = '-';
                                break;
                            }
                            start = (start + 1) % Length;
                        }
                    }
                    else
                        for (int i = 0; i < 2; i++)
                            for (int k = 0; k < Length; k++)
                                if (varFrequences[i, k] == max)
                                {
                                    sb[k] = i.ToString()[0];
                                    string implicant = MergeTerms(t, sb.ToString());
                                    if (!IntersectFalse(implicant))
                                        countImplicants++;
                                    mostFrequencesVariables.Add(implicant);
                                    sb[k] = '-';
                                }

                    if (countImplicants > 0)
                    {
                        for (int i = 0; i < mostFrequencesVariables.Count; i++)
                            if (IntersectFalse(mostFrequencesVariables[i]))
                                mostFrequencesVariables.RemoveAt(i--);
                    }
                    return mostFrequencesVariables[rand.Next(mostFrequencesVariables.Count)];
                }
            }
        }

        public Minimizer(string pathToFile, Form1 _mainForm, int seconds, bool multyExpanding)
        {
            True = new List<string>();
            False = new List<string>();
            ReadFunction(pathToFile);
            ImplicantBuffer = new TernaryTree(Length);
            ExpansionBuffer = new List<string>();
            this.mainForm = _mainForm;
            secondsForCDSearch = seconds;
            this.multyExpanding = multyExpanding;
        }

        private void MultiImplicantExpansion()
        {

            List<string> PrimeImplicants = new List<string>();

            for (int i = 0; i < ExpansionBuffer.Count; i++)
            {
                for (int j = 0; j < Length; j++)
                    PrimeImplicants.Add(Expand(j, ExpansionBuffer[i]));
            }

            ExpansionBuffer = PrimeImplicants.Distinct().ToList();

            string Expand(int start, string implicant)
            {
                StringBuilder sb = new StringBuilder(implicant);
                string result = String.Empty;
                int EllapsedChangings = 0;
                int position = start;
                do
                {
                    if (sb[position] != '-')
                    {
                        char buffer = sb[position];
                        sb[position] = '-';
                        if (IntersectFalse(sb.ToString()))
                            sb[position] = buffer;
                        else
                        {
                            EllapsedChangings++;
                            result = sb.ToString();
                        }
                    }
                    position = (position + 1) % Length;
                    if (position == (start - 1 + Length) % Length)
                        if (EllapsedChangings == 0)
                            break;
                        else
                            EllapsedChangings = 0;
                } while (true);
                return (result != "") ? result : implicant;
            }

        }

        private void ImplicantExpansion()
        {//Последовательное расширение
            for (int i = 0; i < ExpansionBuffer.Count; i++)
            {
                StringBuilder sb = new StringBuilder(ExpansionBuffer[i]);
                int start = rand.Next(Length);
                int EllapsedChangings = 0;
                int position = start;
                do
                {
                    if (sb[position] != '-')
                    {
                        char buffer = sb[position];
                        sb[position] = '-';
                        if (IntersectFalse(sb.ToString()))
                            sb[position] = buffer;
                        else
                        {
                            EllapsedChangings++;
                            ExpansionBuffer[i] = sb.ToString();
                        }
                    }
                    position = (position + 1) % Length;
                    if (position == (start - 1 + Length) % Length)
                        if (EllapsedChangings == 0)
                            break;
                        else
                            EllapsedChangings = 0;
                } while (true);
            }
            ExpansionBuffer = ExpansionBuffer.Distinct().ToList();
        }

        private string SolveCoveringProblem()
        {
            List<string> trueReduced = True.ToList();
            SortedList<string, int> implicantsCovering = new SortedList<string, int>();
            List<string> resultCovering = new List<string>();
            List<string> answer = new List<string>();
            foreach (var str in ExpansionBuffer)
                implicantsCovering.Add(str, CoveringTerms(str));
            do
            {
                int maximum = implicantsCovering.Max((z) => { return z.Value; });
                for (int j = 0; j < implicantsCovering.Count; j++)
                {
                    if (implicantsCovering.ElementAt(j).Value == maximum)
                    {
                        AddResult(implicantsCovering.ElementAt(j).Key);
                        ReduceTrue(trueReduced, implicantsCovering.ElementAt(j).Key);
                        answer.Add(implicantsCovering.ElementAt(j).Key);
                        implicantsCovering.RemoveAt(j--);
                        UpdateValues();
                    }
                }
                if (implicantsCovering.Count == 0 && trueReduced.Count!=0)
                    return "Недостаточно импликант было сгенерировано.";
            } while (trueReduced.Count > 0);

            StringBuilder result = new StringBuilder("");

            StringBuilder buf = new StringBuilder(new string(Enumerable.Repeat('-', Length).ToArray()));

            for (int i = 0; i < answer.Count; i++)
            {
                for (int k = 0; k < Length; k++)
                    if (buf[k] == '-')
                    {
                        if (answer[i][k] != '-')
                            buf[k] = '1';
                    }
            }

            int variables = 0;
            for (int k = 0; k < Length; k++)
                if (buf[k] != '-')
                    variables++;
            mainForm.Invoke((Action)delegate { mainForm.UpdateVC(variables, answer.Count); });

            for (int k = 0; k < resultCovering.Count - 1; k++)
            {
                result.Append(resultCovering[k]);
                result.Append('+');
            }
            result.Append(resultCovering.Last());

            return result.ToString();

            void UpdateValues()
            {
                for (int i = 0; i < implicantsCovering.Count; i++)
                    implicantsCovering[implicantsCovering.ElementAt(i).Key] = CoveringTerms(implicantsCovering.ElementAt(i).Key);
            }

            int CoveringTerms(string implicant)
            {
                int count = 0;
                for (int i = 0; i < trueReduced.Count; i++)
                {
                    for (int k = 0; k < Length; k++)
                    {
                        if (implicant[k] == '-' && k != Length - 1)
                            continue;
                        if (implicant[k] != trueReduced[i][k] && implicant[k] != '-')
                            break;
                        if (k == Length - 1)
                            count++;
                    }
                }
                return count;
            }

            void AddResult(string implicant)
            {
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < Length; i++)
                    if (implicant[i] != '-')
                    {
                        if (implicant[i] == '0')
                            sb.Append('!');
                        sb.Append('X');
                        sb.Append(i);
                    }
                resultCovering.Add(sb.ToString());
            }
        }

        public async Task<string> StartAsync()
        {//todo Асинхронный вызов
            Console.WriteLine("Функция от {0} переменных с {1} определёнными мидтермами.", Length, True.Count + False.Count);
            await Task.Run(() => CD_Search());
            mainForm.Invoke((Action)delegate { mainForm.UpdateFI(ExpansionBuffer.Count); });
            if (multyExpanding)
                await Task.Run(() => MultiImplicantExpansion());
            else
                await Task.Run(() => ImplicantExpansion());
            mainForm.Invoke((Action)delegate { mainForm.UpdatePI(ExpansionBuffer.Count); });
            string result = await Task.Run<string>(() => { return SolveCoveringProblem(); });
            return result;
        }

    }
}
