using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFKPKSoftwareSolutionsTask1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MenuApp> ListApp { get; set; } = new List<MenuApp>();
        private Dictionary<string, List<List<MenuApp>>> ListListsApp { get; set; } = new Dictionary<string, List<List<MenuApp>>>();

        private char lastChar = ' ';
        private int indexGrid = 0;
        private int indexMainGrid = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InListAppAddObjects();
            InListListsAppAddObjects();
            AddInListViewObjects();
            AddInComboListViewObjects();
        }

        private void InListAppAddObjects()
        {
            ListApp.Add(new MenuApp("Zoom", "Images\\image1.png"));
            ListApp.Add(new MenuApp("Sinner", "Images\\image2.png"));
            ListApp.Add(new MenuApp("Access", "Images\\image3.png"));
            ListApp.Add(new MenuApp("Cortana", "Images\\image1.png"));
            ListApp.Add(new MenuApp("Excel", "Images\\image2.png"));
            ListApp.Add(new MenuApp("Discord", "Images\\image3.png"));
            ListApp.Add(new MenuApp("Word", "Images\\image1.png"));
            ListApp.Add(new MenuApp("Visio", "Images\\image2.png"));
            ListApp.Add(new MenuApp("Call of Duty", "Images\\image3.png"));
            ListApp.Add(new MenuApp("Doom", "Images\\image1.png"));
            ListApp.Add(new MenuApp("Azur lane", "Images\\image2.png"));
            ListApp.Add(new MenuApp("Blade and Soul", "Images\\image3.png"));
            ListApp.Add(new MenuApp("Dark Souls", "Images\\image1.png"));
            ListApp.Add(new MenuApp("Terraria", "Images\\image2.png"));
            ListApp.Add(new MenuApp("Valorant", "Images\\image3.png"));
            ListApp.Add(new MenuApp("Warface", "Images\\image1.png"));
            ListApp.Add(new MenuApp("Sniper", "Images\\image2.png"));

            ListApp = ListApp.OrderBy(e => e.Name).ToList();
        }

        private void InListListsAppAddObjects()
        {
            ListListsApp.Add("Производительность", new List<List<MenuApp>>
            {
                new List<MenuApp> { new MenuApp("Office", "Images\\image1.png") },
                new List<MenuApp> { new MenuApp("Word", "Images\\image1.png"), new MenuApp("Excel", "Images\\image2.png"), new MenuApp("Power Point", "Images\\image3.png"), new MenuApp("One Node", "Images\\image4.ico"), },
                new List<MenuApp> { new MenuApp("Почта", "Images\\image3.png") },
                new List<MenuApp> { new MenuApp("Microsoft Edge", "Images\\image3.png") },
                new List<MenuApp> { new MenuApp("Фотографии", "Images\\image3.png") },
                new List<MenuApp> { new MenuApp("(Пусто)", "Images\\image5.png") },
            });

            ListListsApp.Add("Просмотр", new List<List<MenuApp>>
            {
                new List<MenuApp> { new MenuApp("Microsoft Store", "Images\\image1.png") },
                new List<MenuApp> { new MenuApp("Погода", "Images\\image6.png") },
                new List<MenuApp> { new MenuApp("(Пусто)", "Images\\image7.png") },
                new List<MenuApp> { new MenuApp("Solitaire", "Images\\image8.png") },
                new List<MenuApp> { new MenuApp("Ваш телефон", "Images\\image9.png") },
                new List<MenuApp> { new MenuApp("Lol", "Images\\image9.png"), new MenuApp("Prime Video", "Images\\image8.png"), new MenuApp("Index", "Images\\image7.png"), new MenuApp("Doubly", "Images\\image6.png"), },
            });
        }

        private void AddInListViewObjects()
        {
            while (true)
            {
                if (ListApp.Count == 0)
                {
                    break;
                }
                lastChar = ListApp.First().Name[0];
                var list = ListApp.Where(e => e.Name[0] == lastChar).ToList();

                if (list != null)
                {
                    stackPanelLists.Children.Add(new TextBlock { Text = lastChar.ToString(), FontWeight = FontWeights.Bold, Foreground = Brushes.Red, FontSize = 25 });
                    var stackPanel = new ListView
                    {
                        ItemsSource = list,
                        Style = this.Resources["DefaultListView"] as Style,
                        ItemContainerStyle = this.Resources["DefaultConTainer"] as Style,
                    };
                    stackPanelLists.Children.Add(stackPanel);
                }
                foreach (var item in list)
                {
                    ListApp.Remove(item);
                }
            }
        }

        private void AddInComboListViewObjects()
        {
            foreach (var item in ListListsApp)
            {
                indexMainGrid = 0;
                Grid gridMain = new Grid();
                stackComboLists.Children.Add(new TextBlock { Text = item.Key, FontWeight = FontWeights.Bold, Foreground = Brushes.Red, FontSize = 20 });
                stackComboLists.Children.Add(gridMain);
                gridMain.ColumnDefinitions.Add(new ColumnDefinition());
                gridMain.ColumnDefinitions.Add(new ColumnDefinition());
                gridMain.ColumnDefinitions.Add(new ColumnDefinition());
                for (int i = 0; i < Math.Ceiling((double)(item.Value.Count / 3)); i++)
                {
                    gridMain.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100, GridUnitType.Pixel) });
                }
                foreach (var listItems in item.Value)
                {
                    Grid grid = new Grid();
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());

                    if (listItems.Count == 1)
                    {
                        TextBlock text = new TextBlock()
                        {
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Text = listItems.First().Name,
                            FontSize = 10,
                            FontWeight = FontWeights.Bold,
                        };
                        Image image = new Image() { Source = new BitmapImage(new Uri(listItems.First().ImageFullPath)), Stretch = Stretch.Uniform };
                        grid.Children.Add(image);
                        grid.Children.Add(text);

                        Grid.SetRowSpan(image, 2);
                        Grid.SetColumnSpan(image, 3);
                        Grid.SetRow(text, 2);
                        Grid.SetColumnSpan(text, 3);
                    }
                    else
                    {
                        TextBlock text = new TextBlock()
                        {
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Text = "Приложения",
                            FontSize = 10,
                            FontWeight = FontWeights.Bold,
                        };
                        indexGrid = 0;
                        foreach (var obj in listItems)
                        {
                            /*if (listItems[6] == obj)
                                  break;*/

                            Image image = new Image() { Source = new BitmapImage(new Uri(obj.ImageFullPath)), Stretch = Stretch.Uniform };
                            grid.Children.Add(image);
                            Grid.SetColumn(image, indexGrid % 3);
                            Grid.SetRow(image, (int)Math.Floor((double)indexGrid / 3));
                            indexGrid++;
                        }
                        grid.Children.Add(text);

                        Grid.SetRow(text, 2);
                        Grid.SetColumnSpan(text, 3);
                    }
                    gridMain.Children.Add(grid);
                    Grid.SetColumn(grid, indexMainGrid % 3);
                    Grid.SetRow(grid, (int)Math.Floor((double)indexMainGrid / 3));
                    indexMainGrid++;
                }
            }
        }
    }
}
