using System.Windows;

namespace LW_9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool TryParseSegment(string rawX, string rawY,
                                     string segmentName,
                                     out LineSegment segment)
        {
            segment = null;

            if (!double.TryParse(rawX.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double x))
            {
                ShowError($"Некорректное значение X для отрезка {segmentName}.");
                return false;
            }

            if (!double.TryParse(rawY.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double y))
            {
                ShowError($"Некорректное значение Y для отрезка {segmentName}.");
                return false;
            }

            segment = new LineSegment(x, y);
            return true;
        }

        private bool TryParseN(out int n)
        {
            if (!int.TryParse(TxtN.Text, out n))
            {
                ShowError("Некорректное значение целого числа n.");
                return false;
            }
            return true;
        }

        private void ShowError(string message)
        {
            TxtResult.Text = $"⚠ Ошибка: {message}";
        }

        private void ShowResult(string message)
        {
            TxtResult.Text = message;
        }

        private void BtnIntersects_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtAx.Text, TxtAy.Text, "A", out LineSegment a))
            {
                return;
            }

            if (!TryParseSegment(TxtBx.Text, TxtBy.Text, "B", out LineSegment b))
            {
                return;
            }

            bool result = a.Intersects(b);
            ShowResult($"A = {a}\nB = {b}\n\nПересекаются: {result}");
        }

        private void BtnLengthA_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtAx.Text, TxtAy.Text, "A", out LineSegment a))
            {
                return;
            }

            double length = !a;
            ShowResult($"A = {a}\n\n!A (длина) = {length}");
        }

        private void BtnLengthB_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtBx.Text, TxtBy.Text, "B", out LineSegment b))
            {
                return;
            }

            double length = !b;
            ShowResult($"B = {b}\n\n!B (длина) = {length}");
        }

        private void BtnIncA_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtAx.Text, TxtAy.Text, "A", out LineSegment a))
            {
                return;
            }

            LineSegment original = new LineSegment(a);
            LineSegment result = ++a;
            ShowResult($"A до  = {original}\nA++ (расширен на 1 вправо и влево) = {result}");
        }

        private void BtnIncB_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtBx.Text, TxtBy.Text, "B", out LineSegment b))
            {
                return;
            }

            LineSegment original = new LineSegment(b);
            LineSegment result = ++b;
            ShowResult($"B до  = {original}\nB++ (расширен на 1 вправо и влево) = {result}");
        }

        private void BtnSubLeft_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtAx.Text, TxtAy.Text, "A", out LineSegment a))
            {
                return;
            }
            if (!TryParseN(out int n))
            {
                return;
            }

            LineSegment result = a - n;
            ShowResult($"A = {a}\nn = {n}\n\nA – n = {result}  (x уменьшен на {n})");
        }

        private void BtnSubRight_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtBx.Text, TxtBy.Text, "B", out LineSegment b))
            {
                return;
            }
            if (!TryParseN(out int n))
            {
                return;
            }

            LineSegment result = n - b;
            ShowResult($"B = {b}\nn = {n}\n\nn – B = {result}  (y уменьшен на {n})");
        }

        private void BtnCastInt_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtAx.Text, TxtAy.Text, "A", out LineSegment a))
            {
                return;
            }

            int result = a;
            ShowResult($"A = {a}\n\n(int)A (целая часть x) = {result}");
        }

        private void BtnCastDouble_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtBx.Text, TxtBy.Text, "B", out LineSegment b))
            {
                return;
            }

            double result = (double)b;
            ShowResult($"B = {b}\n\n(double)B (координата y) = {result}");
        }

        private void BtnLessOp_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseSegment(TxtAx.Text, TxtAy.Text, "A", out LineSegment a))
            {
                return;
            }
            if (!TryParseSegment(TxtBx.Text, TxtBy.Text, "B", out LineSegment b))
            {
                return;
            }

            bool result = a < b;
            ShowResult($"A = {a}\nB = {b}\n\nA < B = {result}  " +
                       $"({(result ? "отрезки пересекаются" : "отрезки не пересекаются")})");
        }
    }
}
