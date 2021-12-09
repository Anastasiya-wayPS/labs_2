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

namespace lab_8
{
				/// <summary>
				/// Логика взаимодействия для MainWindow.xaml
				/// </summary>
				public partial class MainWindow : Window
				{
								private bool isFirstVariant = true;
								public MainWindow()
								{
												InitializeComponent();
								}

								private void calcButton_Click(object sender, RoutedEventArgs e)
								{
												try
												{
																double answer = 0;
																int x = Convert.ToInt32(xInput.Text);
																int y = Convert.ToInt32(yInput.Text);

																int n = Convert.ToInt32(nInput.Text);
																int r = Convert.ToInt32(rInput.Text);

																int a = Convert.ToInt32(yInput.Text);
																int b = Convert.ToInt32(yInput.Text);
																int c = Convert.ToInt32(yInput.Text);

																if (isFirstVariant)
																{
																				answer = CalcFirst(x, y, n);
																} else {
																				answer = CalcSecond(a, b, c, n, r);
																}

																SetTitle($"Ответ: {answer}");
												}
												catch (Exception ex)
												{
																SetTitle(ex.Message);
												}
								}

								private double CalcFirst(int x, int y, int n)
								{
												double acc = 0;
												int del = 2;
												int pow = 1;
												for (int i = 0; i < n; i++)
												{
																bool isMinus = i % 2 != 0;
																int toDel = i != 0 && isMinus ? x : y;
																double res = Math.Pow(toDel, pow) / del;

																if (isMinus)
																{
																				res *= -1;
																}
																acc += res;
																pow++;
																del *= 3;
												}
												return acc;
								}

								private double CalcSecond(int a, int b, int c, int n, int r)
								{
												double acc = 0;
												for (int i = 0; i < n; i++)
												{
																for (int j = 0; j < r; j++)
																{
																				acc += (a * i + b * j) / (c * Math.Pow(i, j));
																}
												}
												return acc;
								}

								private void SetTitle(String msg)
								{
												Title = msg;
								}

								private void variantRadio_Copy_Checked(object sender, RoutedEventArgs e)
								{
												isFirstVariant = true;
								}

								private void variantRadio_Checked(object sender, RoutedEventArgs e)
								{
												isFirstVariant = false;
								}
				}
}
