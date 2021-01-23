using System.Collections.Generic;

namespace week_08_lab
{
    class Logic
    {
        static readonly string[] OPERATIONS = { "*", "/", "%", "+", "-" };

        private static double convert(string arg)
        {
            double n;
            bool parsed = double.TryParse(arg, out n);
            return parsed ? n : 0;
        }

        public static string solve(List<string> ops)
        {
            int idx;
            double left = 0;
            double right = 0;
            double res = 0;

            foreach (string op in OPERATIONS)
            {
                while (ops.Contains(op))
                {
                    idx = ops.FindIndex(x => x == op);

                    if (idx == 0 || idx == ops.Count) break;

                    System.Diagnostics.Debug.WriteLine($"operator index: {idx}");

                    left = convert(ops[idx - 1]);
                    right = convert(ops[idx + 1]);

                    System.Diagnostics.Debug.WriteLine($"left num: {left}, @ idx: {idx - 1}");
                    System.Diagnostics.Debug.WriteLine($"right num: {right}, @ idx: {idx + 1}");
                    System.Diagnostics.Debug.WriteLine($"ops size: {ops.Count}\n");

                    switch (op)
                    {
                        case "*":
                            res = left * right;
                            break;

                        case "/":
                            if (right == 0) return "NaN";
                            res = left / right;
                            break;

                        case "%":
                            if (right == 0) return "NaN";
                            res = left % right;
                            break;

                        case "+":
                            res = left + right;
                            break;

                        case "-":
                            res = left - right;
                            break;
                    }
                    ops.RemoveRange(idx - 1, 3);
                    ops.Insert(idx - 1, res.ToString());
                }
            }

            return res.ToString();
        }
    }
}
