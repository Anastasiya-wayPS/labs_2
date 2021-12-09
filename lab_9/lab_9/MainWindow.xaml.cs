using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_9
{
				/// <summary>
				/// Логика взаимодействия для MainWindow.xaml
				/// </summary>
				public partial class MainWindow : Window
				{
								public MainWindow()
								{
												InitializeComponent();
								}

								private void button_Click(object sender, RoutedEventArgs e)
								{
												try
												{
																int n = Convert.ToInt32(nInput.Text);
																int k = Convert.ToInt32(nInput.Text);

																int x = Convert.ToInt32(nInput.Text);
																int f = Convert.ToInt32(nInput.Text);
																int y = Convert.ToInt32(nInput.Text);

																double res = 0;

																for (int i = 0; i < n; i++)
																{
																				for (int j = 0; j < k; j++)
																				{
																								res += (Math.Sin(x) * Math.Pow(x, i) + Math.Pow(f, i) * Math.Pow(y, i)) / (i * j);
																				}
																}

																SetResult(res);
												}
												catch
												{
																SetResult(0);
												}
								}

								private void SetResult(double toSet)
								{
												label10.Content = toSet;
												label8.Content = Convert.ToString((int)toSet, 8);
												label16.Content = Convert.ToString((int)toSet, 16);

								}
				}
}
