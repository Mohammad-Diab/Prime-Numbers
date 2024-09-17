using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prime_Numbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static StreamWriter SW1;
        public static StreamWriter SW2;
        public static StreamWriter SW3;
        public static StreamWriter SW4;
        public static string Address1;
        public static string Address2;
        public static string Address3;
        public static string Address4;
        public static long Count1;
        public static long Count2;
        public static long Count3;
        public static long Count4;
        string Address;
        public static Int64 n = 0;
        long count = 0;
        bool Is_started = false, View_number = false;
        public static string[] Labels;
        public static string[] EnLabels = { "Prime Numbers", "Find prime numbers which is smaller than:", "Prime Numbers (Methods &...", "Slowest", "Slow", "Medium", "Fast", "*Very Fast", "View Numbers", "Setting", "Help", "about", "'", "' Prime numbers have been saved'", "'\nin '", "' Millisecond", "You should choose a file name!", "The number you have chosen must be in ", "Select folder to put files in:", "You should choose a folder!", "Text Document", "First", "Second", "Third", "Fourth", "Language", "Save", "Cancel", "Close", "The Fastest", "The help file was not found:\n" };
        public static string[] ArLabels = { "الأعداد الأولية", "إيجاد الأعداد الأولية التي هي أصغر أو تساوي:", "الأعداد الأولية (الطرق والتحسينات)", "الأبطئ", "بطيء", "متوسط السرعة", "سريع", "*سريع جدا", "عرض الأعداد", "اعدادات", "مساعدة", "عن", "تم حفظ '", "' رقم أولى الى المسار'", "'\nخلال '", "' ميلي ثانية", "يجب اختيار اسم ملف", "يجب اختيار العدد ضمن المجال ", "حدد مجلدا لنضع الملفات فيه", "يجب اختيار مجلد", "مستند نصي", "الملف الاول", "الملف الثاني", "الملف الثالث", "الملف الرابع", "اللغة", "حفظ", "الغاء", "أغلق", "الأسرع", "لم يتم العثور على ملف المساعدة:\n" };
        public static List<int> Division;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool[] div = new bool[1000001];
            for (int i = 0; i <= 1000000; i++)
                div[i] = false;
            Division = new List<int>();
            for (int i = 2; i <= 1000; i++)
                if (!div[i])
                    Parallel.For(2, 1000000 / i + 1, (j) => { div[j * i] = true; });
            for (int i = 2; i < div.Length; i++)
                if (!div[i])
                    Division.Add(i);
            if (Properties.Settings.Default.Language)
                Labels = EnLabels;
            else
                Labels = ArLabels;
            ChangeLang();
        }

        private void ChangeLang()
        {
            this.Title = Labels[0];
            Label1.Content = Labels[1];
            GroupBox1.Header = Labels[2];
            Slowest.Content = Labels[3];
            Slow.Content = Labels[4];
            Medium.Content = Labels[5];
            Fast.Content = Labels[6];
            Fastest.Content = Labels[7];
            New_Way.Content = Labels[29];
            View_Numbers.Content = Labels[8];
            Setting.ToolTip = Labels[9];
            Help.ToolTip = Labels[10];
            about.ToolTip = Labels[11];
            if (MainWindow.Labels[0][0].Equals('P'))
                this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            else
                this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
        }

        private void Primary1()
        {
            long count = 2;
            SW1 = new StreamWriter(Address1);
            SW1.WriteLine(2);
            SW1.WriteLine(3);
            bool prime;
            int primeIndex;
            int plus = 2;
            for (long i = 5; i <= n / 4; i += plus)
            {
                prime = true;
                double y = Math.Sqrt(i);
                primeIndex = 0;
                while (primeIndex < Division.Count && Division[primeIndex] <= y)
                {
                    if (i % Division[primeIndex] == 0)
                    {
                        prime = false;
                        break;
                    }
                    primeIndex++;
                }
                if (prime == true)
                {
                    count++;
                    SW1.WriteLine(i);
                }
                if (plus == 2 && i > 5)
                    plus = 4;
                else
                    plus = 2;
            }
            SW1.Close();
            Count1 = count;
        }

        private void Primary2()
        {
            int plus;
            long start = n / 4 + 1;
            while (true)
            {
                if (start % 6 == 1)
                {
                    plus = 2;
                    break;
                }
                else if (start % 6 == 5)
                {
                    plus = 4;
                    break;
                }
                else
                {
                    start++;
                    continue;
                }
            }
            long count = 0;
            SW2 = new StreamWriter(Address2);
            bool prime;
            int primeIndex;
            for (long i = start; i <= n / 2; i += plus)
            {
                if (plus == 2)
                    plus = 4;
                else
                    plus = 2;
                prime = true;
                double y = Math.Sqrt(i);
                primeIndex = 0;
                while (primeIndex < Division.Count && Division[primeIndex] <= y)
                {
                    if (i % Division[primeIndex] == 0)
                    {
                        prime = false;
                        break;
                    }
                    primeIndex++;
                }
                if (prime == true)
                {
                    count++;
                    SW2.WriteLine(i);
                }
            }
            SW2.Close();
            Count2 = count;
        }

        private void Primary3()
        {
            int plus;
            long start = n / 2 + 1;
            while (true)
            {
                if (start % 6 == 1)
                {
                    plus = 2;
                    break;
                }
                else if (start % 6 == 5)
                {
                    plus = 4;
                    break;
                }
                else
                {
                    start++;
                    continue;
                }
            }
            long count = 0;
            SW3 = new StreamWriter(Address3);
            bool prime;
            int primeIndex;
            for (long i = start; i <= 3 * n / 4; i += plus)
            {
                if (plus == 2)
                    plus = 4;
                else
                    plus = 2;
                prime = true;
                double y = Math.Sqrt(i);
                primeIndex = 0;
                while (primeIndex < Division.Count && Division[primeIndex] <= y)
                {
                    if (i % Division[primeIndex] == 0)
                    {
                        prime = false;
                        break;
                    }
                    primeIndex++;
                }
                if (prime == true)
                {
                    count++;
                    SW3.WriteLine(i);
                }
            }
            SW3.Close();
            Count3 = count;
        }

        private void Primary4()
        {
            int plus;
            long start = 3 * n / 4 + 1;
            while (true)
            {
                if (start % 6 == 1)
                {
                    plus = 2;
                    break;
                }
                else if (start % 6 == 5)
                {
                    plus = 4;
                    break;
                }
                else
                {
                    start++;
                    continue;
                }
            }
            long count = 0;
            SW4 = new StreamWriter(Address4);
            bool prime;
            int primeIndex;
            for (long i = start; i <= n; i += plus)
            {
                if (plus == 2)
                    plus = 4;
                else
                    plus = 2;
                prime = true;
                double y = Math.Sqrt(i);
                primeIndex = 0;
                while (primeIndex < Division.Count && Division[primeIndex] <= y)
                {
                    if (i % Division[primeIndex] == 0)
                    {
                        prime = false;
                        break;
                    }
                    primeIndex++;
                }
                if (prime == true)
                {
                    count++;
                    SW4.WriteLine(i);
                }
            }
            SW4.Close();
            Count4 = count;
        }

        private void Slowest_Click(object sender, RoutedEventArgs e)
        {
            Int64.TryParse(TextBox1.Text, out n);
            if (n > 2 && n < 1200000001)
            {
                count = 1;
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = Labels[20] + "(*.Txt) |*.txt";
                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Address1 = Address2 = Address3 = Address4 = String.Empty;
                    Address = SFD.FileName;
                    StreamWriter SW = new StreamWriter(Address);
                    long m1 = DateTime.Now.Ticks;
                    SW.WriteLine(2);
                    bool d;
                    for (int i = 3; i <= n; i++)
                    {
                        d = true;
                        for (int j = 2; j < i; j++)
                            if (i % j == 0)
                            {
                                d = false;
                                break;
                            }
                        if (d == true)
                        {
                            count++;
                            SW.WriteLine(i);
                        }
                    }
                    SW.Close();
                    long m2 = DateTime.Now.Ticks;
                    System.Windows.MessageBox.Show(string.Concat(Labels[12], count, Labels[13], Address, Labels[14], ((Double)(m2 - m1)) / 10000, Labels[15]), Labels[0], MessageBoxButton.OK, MessageBoxImage.Information);
                    Is_started = true;
                    if (View_number) View_Number();
                }
                else
                    System.Windows.MessageBox.Show(Labels[16], Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                System.Windows.MessageBox.Show(Labels[17] + "[3,1200000000]", Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Slow_Click(object sender, RoutedEventArgs e)
        {
            Int64.TryParse(TextBox1.Text, out n);
            if (n > 2 && n <= 1000000000000)
            {
                count = 1;
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = Labels[20] + "(*.Txt) |*.txt";
                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Address = SFD.FileName;
                    Address1 = Address2 = Address3 = Address4 = String.Empty;
                    StreamWriter SW = new StreamWriter(Address);
                    long m1 = DateTime.Now.Ticks;
                    SW.WriteLine(2);
                    bool prime;
                    for (long i = 3; i <= n; i++)
                    {
                        prime = true;
                        double y = Math.Sqrt(i);
                        for (int j = 2; j <= y; j++)
                            if (i % j == 0)
                            {
                                prime = false;
                                break;
                            }
                        if (prime == true)
                        {
                            count++;
                            SW.WriteLine(i);
                        }
                    }
                    SW.Close();
                    long m2 = DateTime.Now.Ticks;
                    System.Windows.MessageBox.Show(string.Concat(Labels[12], count, Labels[13], Address, Labels[14], ((Double)(m2 - m1)) / 10000, Labels[15]), Labels[0], MessageBoxButton.OK, MessageBoxImage.Information);
                    Is_started = true;
                    if (View_number) View_Number();
                }
                else
                    System.Windows.MessageBox.Show(Labels[16], Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                System.Windows.MessageBox.Show(Labels[17] + "[3,1000000000000]", Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            Int64.TryParse(TextBox1.Text, out n);
            if (n > 2 && n <= 1000000000000)
            {
                count = 1;
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = Labels[20] + "(*.Txt) |*.txt";
                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Address1 = Address2 = Address3 = Address4 = String.Empty;
                    Address = SFD.FileName;
                    StreamWriter SW = new StreamWriter(Address);
                    long m1 = DateTime.Now.Ticks;
                    SW.WriteLine(2);
                    bool prime;
                    int primeIndex;
                    for (long i = 3; i <= n; i += 2)
                    {
                        prime = true;
                        double y = Math.Sqrt(i);
                        primeIndex = 0;
                        while (primeIndex < Division.Count && Division[primeIndex] <= y)
                        {
                            if (i % Division[primeIndex] == 0)
                            {
                                prime = false;
                                break;
                            }
                            primeIndex++;
                        }
                        if (prime == true)
                        {
                            count++;
                            SW.WriteLine(i);
                        }
                    }
                    SW.Close();
                    long m2 = DateTime.Now.Ticks;
                    System.Windows.MessageBox.Show(string.Concat(Labels[12], count, Labels[13], Address, Labels[14], ((Double)(m2 - m1)) / 10000, Labels[15]), Labels[0], MessageBoxButton.OK, MessageBoxImage.Information);
                    Is_started = true;
                    if (View_number) View_Number();
                }
                else
                    System.Windows.MessageBox.Show(Labels[16], Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                System.Windows.MessageBox.Show(Labels[17] + "[3,1000000000000]", Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Fast_Click(object sender, RoutedEventArgs e)
        {
            Int64.TryParse(TextBox1.Text, out n);
            if (n > 5 && n <= 1000000000000)
            {
                count = 2;
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = Labels[20] + "(*.Txt) |*.txt";
                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Address1 = Address2 = Address3 = Address4 = String.Empty;
                    Address = SFD.FileName;
                    StreamWriter SW = new StreamWriter(Address);
                    long m1 = DateTime.Now.Ticks;
                    SW.WriteLine(2);
                    SW.WriteLine(3);
                    bool prime;
                    int primeIndex;
                    int plus = 2;
                    for (long i = 5; i <= n; i += plus)
                    {
                        prime = true;
                        double y = Math.Sqrt(i);
                        primeIndex = 0;
                        while (primeIndex < Division.Count && Division[primeIndex] <= y)
                        {
                            if (i % Division[primeIndex] == 0)
                            {
                                prime = false;
                                break;
                            }
                            primeIndex++;
                        }
                        if (prime == true)
                        {
                            count++;
                            SW.WriteLine(i);
                        }
                        if (plus == 2 && i > 5)
                            plus = 4;
                        else
                            plus = 2;
                    }
                    SW.Close();
                    long m2 = DateTime.Now.Ticks;
                    System.Windows.MessageBox.Show(string.Concat(Labels[12], count, Labels[13], Address, Labels[14], ((Double)(m2 - m1)) / 10000, Labels[15]), Labels[0], MessageBoxButton.OK, MessageBoxImage.Information);
                    Is_started = true;
                    if (View_number) View_Number();
                }
                else
                    System.Windows.MessageBox.Show(Labels[16], Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                System.Windows.MessageBox.Show(Labels[17] + "[6,1000000000000]", Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Faster_Click(object sender, RoutedEventArgs e)
        {
            Int64.TryParse(TextBox1.Text, out n);
            if (n >= 16 && n <= 1000000000000)
            {
                Address = String.Empty;
                count = 2;
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                FBD.Description = Labels[18];
                if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    do
                    {
                        Random Rand = new Random((Int32)DateTime.Now.Ticks);
                        int x = Rand.Next();
                        Address1 = FBD.SelectedPath + "\\" + Labels[21] + x + ".txt";
                        Address2 = FBD.SelectedPath + "\\" + Labels[22] + x + ".txt";
                        Address3 = FBD.SelectedPath + "\\" + Labels[23] + x + ".txt";
                        Address4 = FBD.SelectedPath + "\\" + Labels[24] + x + ".txt";
                    } while (File.Exists(Address1) || File.Exists(Address2) || File.Exists(Address3) || File.Exists(Address4));
                    string Folder = FBD.SelectedPath;
                    GroupBox1.IsEnabled = false;
                    Thread t = new Thread(() =>
                    {
                        long m1 = DateTime.Now.Ticks;
                        Thread t1 = new Thread(Primary1);
                        Thread t2 = new Thread(Primary2);
                        Thread t3 = new Thread(Primary3);
                        Thread t4 = new Thread(Primary4);
                        t1.Priority = System.Threading.ThreadPriority.Highest;
                        t3.Priority = System.Threading.ThreadPriority.Highest;
                        t1.IsBackground = t2.IsBackground = t3.IsBackground = t4.IsBackground = true;
                        t1.Start();
                        t2.Start();
                        t3.Start();
                        t4.Start();
                        t1.Join();
                        t2.Join();
                        t3.Join();
                        t4.Join();
                        long m2 = DateTime.Now.Ticks;
                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            GroupBox1.IsEnabled = true;
                            System.Windows.MessageBox.Show(string.Concat(Labels[12], Count1 + Count2 + Count3 + Count4, Labels[13], Folder, Labels[14], ((Double)(m2 - m1)) / 10000, Labels[15]), Labels[0], MessageBoxButton.OK, MessageBoxImage.Information);
                        }));
                    });
                    t.IsBackground = true;
                    t.Start();
                }
                else
                    System.Windows.MessageBox.Show(Labels[19], Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                System.Windows.MessageBox.Show(Labels[17] + "[16,1000000000000]", Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void The_Fastest_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            Int64.TryParse(TextBox1.Text, out n);
            if (n > 2 && n < 2147483647)
            {
                try
                {
                    bool[] num = new bool[n + 1];
                    long m1 = DateTime.Now.Ticks;
                    double y = Math.Sqrt(n) + 1;
                    for (int i = 2; i <= y; i++)
                    {
                        if (num[i])
                            continue;
                        Parallel.For(2, n / i + 1, (j) => { num[j * i] = true; });
                    }
                    long m2 = DateTime.Now.Ticks;
                    SaveFileDialog SFD = new SaveFileDialog();
                    SFD.Filter = Labels[20] + "(*.Txt) |*.txt";
                    if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Address1 = Address2 = Address3 = Address4 = String.Empty;
                        Address = SFD.FileName;
                        StreamWriter SW = new StreamWriter(Address);
                        for (int i = 2; i < n + 1; i++)
                            if (!num[i])
                            {
                                count++;
                                SW.WriteLine(i);
                            }
                        SW.Close();
                        Is_started = true;
                        if (View_number)
                        {
                            NumberList.Items.Clear();
                            this.Width = 385;
                            NumberList.Visibility = Visibility.Visible;
                            for (int i = 2; i < n + 1; i++)
                                if (!num[i])
                                    NumberList.Items.Add(i);
                        }
                        System.Windows.MessageBox.Show(string.Concat(Labels[12], count, Labels[13], Address, Labels[14], ((Double)(m2 - m1)) / 10000, Labels[15]), Labels[0], MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        System.Windows.MessageBox.Show(Labels[16], Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
                    num = null;
                }
                catch (Exception ex)
                { System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
                System.Windows.MessageBox.Show(Labels[17] + "[3,2147483646]", Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting window = new Setting();
            window.ShowDialog();
            ChangeLang();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            string HelpFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Help.ppsx");
            if (File.Exists(HelpFile))
            {
                try
                {
                    System.Diagnostics.ProcessStartInfo PSI = new System.Diagnostics.ProcessStartInfo(HelpFile);
                    System.Diagnostics.Process.Start(PSI);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                System.Windows.MessageBox.Show(Labels[30] + HelpFile, Labels[0], MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            Info Win2 = new Info();
            Win2.ShowDialog();
        }

        private void ViewNumber_Checked(object sender, RoutedEventArgs e)
        {
            if (Address != null)
                if (Is_started && !Address.Equals(String.Empty) && File.Exists(Address))
                    View_Number();
            View_number = true;
        }

        private void ViewNumber_Unchecked(object sender, RoutedEventArgs e)
        {
            NumberList.Items.Clear();
            this.Width = 325;
            NumberList.Visibility = Visibility.Collapsed;
            View_number = false;
        }

        private void View_Number()
        {
            try
            {
                NumberList.Items.Clear();
                this.Width = 385;
                NumberList.Visibility = Visibility.Visible;
                using (StreamReader SR = new StreamReader(File.OpenRead(Address)))
                    while (!SR.EndOfStream)
                        NumberList.Items.Add(SR.ReadLine());
            }
            catch (Exception ex)
            { System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}