using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public SqlConnection sqlConnection = null;
        public SqlCommand commandForGettingPoint = null;
        private string queryForGettingPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            sqlConnection.Open();
            percentMode.SelectedItem = "Массовые проценты";
        }

        // Метод для вывода координат мышки в текст-боксы
        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            OX.Text = Math.Round(mouseCoordX, 2).ToString();
            OY.Text = Math.Round(100 - mouseCoordX, 2).ToString();
            //formsPlot1.Render();
        }

        // Нажатие на кнопку "Очистить"
        private void clearPlotButton_Click(object sender, EventArgs e)
        {
            formsPlot1.plt.Clear();
            formsPlot1.Render();
        }


        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        // Нажатие на кнопку "Добавить"
        private void button4_Click(object sender, EventArgs e)
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
        }

        // Перегрузка построения по Безье для трёх точек
        private List<double[]> bezierBuilding(double P0x, double P0y, double P1xBefore, double Py, double P3x, double P3y)
        {
            double[] arrayForCheckY = new double[10001];
            double[] arrayForCheckX = new double[10001];
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[10001];
            double[] arrayY = new double[10001];
            int i;

            double P1yBefore, P1x, P1y, P2x, P2y;
            for (double j = 0.50; j < 0.999; j += 0.001)
            {
                // Высчитываем координату y для одной направляющей точки
                P1yBefore = ((Py - (0.25 * P0y)) / j);
                // Пересчитываем координаты для двух направляющих точек
                P1x = P0x + ((2 * (P1xBefore - P0x)) / 3);
                P1y = P0y + ((2 * (P1yBefore - P0y)) / 3);
                P2x = P1xBefore + ((P3x - P1xBefore) / 3);
                P2y = P1yBefore + ((P3y - P1yBefore) / 3);
                i = 0;
                // Заполняем массивы по формулам построения кривых Безье
                for (double t = 0; t <= 1; t += 0.0001)
                {
                    arrayX[i] = Math.Pow((1 - t), 3) * P0x + 3 * t * Math.Pow((1 - t), 2) * P1x
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2x + Math.Pow(t, 3) * P3x;
                    arrayY[i] = Math.Pow((1 - t), 3) * P0y + 3 * t * Math.Pow((1 - t), 2) * P1y
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2y + Math.Pow(t, 3) * P3y;


                    arrayForCheckX[i] = Math.Round(arrayX[i], 2);
                    arrayForCheckY[i] = Math.Round(arrayY[i]);

                    i++;
                }

                if (arrayForCheckX.Contains(P1xBefore) && arrayForCheckY[Array.IndexOf(arrayForCheckX, P1xBefore)] == Py)
                {
                    formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Black, markerSize: 0);
                    formsPlot1.plt.Axis(0, 7, 600, 1600);
                    formsPlot1.plt.AxisBounds(0, 7, 600, 1600);
                    formsPlot1.Render();
                    break;
                }
            }
            return new List<double[]> { arrayX, arrayY };
        }

        // Перегрузка построения по Безье для четырёх точек
        private List<double[]> bezierBuilding(double P0x, double P0y, double P1xBefore, double Py, double P2xCheck, double P2yCheck, double P3x, double P3y)
        {
            double[] arrayForCheckY = new double[10001];
            double[] arrayForCheckX = new double[10001];
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[10001];
            double[] arrayY = new double[10001];
            int i;

            double P1yBefore, P1x, P1y, P2x, P2y;
            for (double j = 0.50; j < 0.999; j += 0.001)
            {
                // Высчитываем координату y для одной направляющей точки
                P1yBefore = ((Py - (0.25 * P0y)) / j);
                // Пересчитываем координаты для двух направляющих точек
                P1x = P0x + ((2 * (P1xBefore - P0x)) / 3);
                P1y = P0y + ((2 * (P1yBefore - P0y)) / 3);
                P2x = P1xBefore + ((P3x - P1xBefore) / 3);
                P2y = P1yBefore + ((P3y - P1yBefore) / 3);
                i = 0;
                // Заполняем массивы по формулам построения кривых Безье
                for (double t = 0; t <= 1; t += 0.0001)
                {
                    arrayX[i] = Math.Pow((1 - t), 3) * P0x + 3 * t * Math.Pow((1 - t), 2) * P1x
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2x + Math.Pow(t, 3) * P3x;
                    arrayY[i] = Math.Pow((1 - t), 3) * P0y + 3 * t * Math.Pow((1 - t), 2) * P1y
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2y + Math.Pow(t, 3) * P3y;


                    arrayForCheckX[i] = Math.Round(arrayX[i], 2);
                    arrayForCheckY[i] = Math.Round(arrayY[i]);

                    i++;
                }

                if (arrayForCheckX.Contains(P1xBefore) && arrayForCheckY[Array.IndexOf(arrayForCheckX, P1xBefore)] == Py)
                {
                    formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Black, markerSize: 0);
                    formsPlot1.plt.Axis(0, 7, 600, 1600);
                    formsPlot1.plt.AxisBounds(0, 7, 600, 1600);
                    formsPlot1.Render();
                    break;
                }
            }
            return new List<double[]> { arrayX, arrayY };
        }

        // Перегрузка построения по Безье для двух точек
        private List<double[]> bezierBuilding(double P0x, double P0y, double P3x, double P3y)
        {
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[2];
            double[] arrayY = new double[2];

            arrayX[0] = P0x;
            arrayX[1] = P3x;

            arrayY[0] = P0y;
            arrayY[1] = P3y;

            formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Black, markerSize: 0);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            /*formsPlot1.plt.AxisBounds(0, 4.4, 1100, 1550);*/
            formsPlot1.Render();
            return new List<double[]> { arrayX, arrayY };
        }

        private void fullDiagram_Click(object sender, EventArgs e)
        {
            fillAreas();
        }

        // Метод для получения точки из БД
        private List<double> getPointFromDB(string nameOfPoint, int NumberOfColorGroup)
        {
            queryForGettingPoint = string.Format("SELECT {0} FROM {1} WHERE NumberOfColorGroup1 = {2}" +
                " OR NumberOfColorGroup2 = {2}", nameOfPoint, nameOfDiagram.Text.Replace("-", ""), NumberOfColorGroup);
            commandForGettingPoint = new SqlCommand(queryForGettingPoint, sqlConnection);
            List<double> listOfPoints = new List<double> { };
            SqlDataReader sqlDataReader = commandForGettingPoint.ExecuteReader();

            while (sqlDataReader.Read())
            {
                listOfPoints.Add(Convert.ToDouble($"{sqlDataReader[nameOfPoint]}"));
            }
            if (sqlDataReader != null)
            {
                sqlDataReader.Close();
            }
            return listOfPoints;
        }

        public void fillAreas()
        {
            var listOfBezierMassives = new List<double[]> { };
            var massivesX = new List<double[]> { };
            var massivesY = new List<double[]> { };
            int numberOfAreas = 0;

            try
            {
                string queryForGettingPoints = string.Format("SELECT MAX(NumberOfColorGroup1) FROM [{0}]", nameOfDiagram.Text.Replace("-", ""));
                SqlCommand commandForCount = new SqlCommand(queryForGettingPoints, sqlConnection);
                numberOfAreas = (int)commandForCount.ExecuteScalar();
            }
            catch (Exception)
            {
                MessageBox.Show("Такого соединения нет в базе!");
            }

            // Перебор областей, то есть групп
            for (int i = 1; i <= numberOfAreas; i++)
            {
                // Считаем, сколько строк принадлежат одной группе
                string queryForCountOneGroupRows = string.Format("SELECT COUNT(*) FROM [{0}] WHERE NumberOfColorGroup1 = {1}" +
                    " OR NumberOfColorGroup2 = {1}", nameOfDiagram.Text.Replace("-", ""), i);
                SqlCommand commandForCountOneGroupRows = new SqlCommand(queryForCountOneGroupRows, sqlConnection);
                int numberOfOneGroupRows = (int)commandForCountOneGroupRows.ExecuteScalar();
                // Определяем id первого элемента с нужной группой
                string queryForId = string.Format("SELECT Id FROM [{0}] WHERE NumberOfColorGroup1 = {1}" +
                    " OR NumberOfColorGroup2 = {1}", nameOfDiagram.Text.Replace("-", ""), i);
                SqlCommand commandForId = new SqlCommand(queryForCountOneGroupRows, sqlConnection);
                int id = (int)commandForId.ExecuteScalar();
                var X0 = getPointFromDB("X0", i);
                var Y0 = getPointFromDB("Y0", i);
                var X1 = getPointFromDB("X1", i);
                var Y1 = getPointFromDB("Y1", i);
                var X2 = getPointFromDB("X2", i);
                var Y2 = getPointFromDB("Y2", i);
                var X3 = getPointFromDB("X3", i);
                var Y3 = getPointFromDB("Y3", i);

                // Перебор строк в одной области
                for (int j = 0; j < numberOfOneGroupRows; j++)
                {

                    if (X1[j] == -300 && X2[j] == -300)
                    {
                        listOfBezierMassives = bezierMassives(X0[j], Y0[j], X3[j], Y3[j]);
                        massivesX.Add(listOfBezierMassives[0]);
                        massivesY.Add(listOfBezierMassives[1]);
                    }
                    else if (X1[j] != -300 && X2[j] == -300)
                    {
                        listOfBezierMassives = bezierMassives(X0[j], Y0[j], X1[j], Y1[j], X3[j], Y3[j]);
                        massivesX.Add(listOfBezierMassives[0]);
                        massivesY.Add(listOfBezierMassives[1]);
                    }
                }

                buildingPolygon(massivesX, massivesY);
            }
        }

        public void buildingPolygon(List<double[]> listOfMassivesX, List<double[]> listOfMassivesY)
        {
            var massivesForPolygonX = new List<double[]> { };
            var massivesForPolygonY = new List<double[]> { };

            massivesForPolygonX.Add(listOfMassivesX[0]);
            listOfMassivesX.RemoveAt(0);
            massivesForPolygonY.Add(listOfMassivesY[0]);
            listOfMassivesY.RemoveAt(0);

            int listLength = listOfMassivesX.Count();
            for (int i = 0; i < listLength; i++)
            {
                for (int j = 0; j < listOfMassivesX.Count(); j++)
                {
                    if (massivesForPolygonX.Count() == i)
                    {
                        return;
                    }
                    if (Math.Round(listOfMassivesX[j][0], 2) == Math.Round(massivesForPolygonX[i][massivesForPolygonX[i].Count() - 1], 2) &&
                        Math.Round(listOfMassivesY[j][0], 2) == Math.Round(massivesForPolygonY[i][massivesForPolygonY[i].Count() - 1], 2))
                    {
                        massivesForPolygonX.Add(listOfMassivesX[j]);
                        listOfMassivesX.Remove(listOfMassivesX[j]);

                        massivesForPolygonY.Add(listOfMassivesY[j]);
                        listOfMassivesY.Remove(listOfMassivesY[j]);
                        break;
                    }
                    else if (Math.Round(listOfMassivesX[j][listOfMassivesX[j].Count() - 1], 2) == Math.Round(massivesForPolygonX[i][massivesForPolygonX[i].Count() - 1], 2) &&
                        Math.Round(listOfMassivesY[j][listOfMassivesY[j].Count() - 1], 2) == Math.Round(massivesForPolygonY[i][massivesForPolygonY[i].Count() - 1], 2))
                    {
                        massivesForPolygonX.Add(reversedArray(listOfMassivesX[j]));
                        listOfMassivesX.Remove(listOfMassivesX[j]);

                        massivesForPolygonY.Add(reversedArray(listOfMassivesY[j]));
                        listOfMassivesY.Remove(listOfMassivesY[j]);
                        break;
                    }
                }
            }
            if (listOfMassivesX.Count() != 0)
            {
                buildingReadyPoints(listOfMassivesX, listOfMassivesY);
                return;
            }
            // Объединяем массивы, заливая их в новый unitedMassives
            double[] unitedMassiveX = uniteMassives(massivesForPolygonX);
            double[] unitedMassiveY = uniteMassives(massivesForPolygonY);

            // Строим один полигон
            formsPlot1.plt.PlotPolygon(
                    xs: unitedMassiveX,
                    ys: unitedMassiveY,
                    lineWidth: 2,
                    fillAlpha: .5,
                    lineColor: Color.Black);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            formsPlot1.plt.AxisBounds(0, 7, 600, 1600);
            formsPlot1.Render();
        }

        // МЕТОД ДЛЯ ДОРАБОТКИ!!!
        // Метод для расчёта массивов при построении кривых Безье по трём точкам
        public List<double[]> bezierMassives(double P0x, double P0y, double P1xBefore, double Py, double P3x, double P3y)
        {
            double[] arrayForCheckY = new double[10001];
            double[] arrayForCheckX = new double[10001];
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[10001];
            double[] arrayY = new double[10001];
            int i;

            double P1yBefore, P1x, P1y, P2x, P2y;
            for (double j = 0.55; j < 0.999; j += 0.001)
            {
                // Высчитываем координату y для одной направляющей точки
                P1yBefore = ((Py - (0.25 * P0y)) / j);
                // Пересчитываем координаты для двух направляющих точек
                P1x = P0x + ((2 * (P1xBefore - P0x)) / 3);
                P1y = P0y + ((2 * (P1yBefore - P0y)) / 3);
                P2x = P1xBefore + ((P3x - P1xBefore) / 3);
                P2y = P1yBefore + ((P3y - P1yBefore) / 3);
                i = 0;
                // Заполняем массивы по формулам построения кривых Безье
                for (double t = 0; t <= 1; t += 0.0001)
                {
                    arrayX[i] = Math.Pow((1 - t), 3) * P0x + 3 * t * Math.Pow((1 - t), 2) * P1x
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2x + Math.Pow(t, 3) * P3x;
                    arrayY[i] = Math.Pow((1 - t), 3) * P0y + 3 * t * Math.Pow((1 - t), 2) * P1y
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2y + Math.Pow(t, 3) * P3y;


                    arrayForCheckX[i] = Math.Round(arrayX[i], 2);
                    arrayForCheckY[i] = Math.Round(arrayY[i]);

                    i++;
                }

                if (arrayForCheckX.Contains(P1xBefore) && arrayForCheckY[Array.IndexOf(arrayForCheckX, P1xBefore)] == Py)
                {
                    return new List<double[]> { arrayX, arrayY };
                }
            }
            return new List<double[]> { arrayX, arrayY };
        }

        // МЕТОД ДЛЯ ДОРАБОТКИ!!!
        // Метод для расчёта массивов при построении кривых Безье по двум точкам
        public List<double[]> bezierMassives(double P0x, double P0y, double P3x, double P3y)
        {
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[2];
            double[] arrayY = new double[2];

            arrayX[0] = P0x;
            arrayX[1] = P3x;

            arrayY[0] = P0y;
            arrayY[1] = P3y;

            return new List<double[]> { arrayX, arrayY };
        }

        // Метод сортировки и объединения массивов
        public List<double[]> massiveSorting(List<double[]> listOfMassivesX, List<double[]> listOfMassivesY)
        {
            var massivesForPolygonX = new List<double[]> { };
            var massivesForPolygonY = new List<double[]> { };

            massivesForPolygonX.Add(listOfMassivesX[0]);
            listOfMassivesX.RemoveAt(0);
            massivesForPolygonY.Add(listOfMassivesY[0]);
            listOfMassivesY.RemoveAt(0);

            int listLength = listOfMassivesX.Count();
            for (int i = 0; i < listLength; i++)
            {
                for (int j = 0; j < listOfMassivesX.Count(); j++)
                {
                    if (Math.Round(listOfMassivesX[j][0], 2) == Math.Round(massivesForPolygonX[i][massivesForPolygonX[i].Count() - 1], 2) &&
                        Math.Round(listOfMassivesY[j][0], 2) == Math.Round(massivesForPolygonY[i][massivesForPolygonY[i].Count() - 1], 2))
                    {
                        massivesForPolygonX.Add(listOfMassivesX[j]);
                        listOfMassivesX.Remove(listOfMassivesX[j]);

                        massivesForPolygonY.Add(listOfMassivesY[j]);
                        listOfMassivesY.Remove(listOfMassivesY[j]);
                        break;
                    }
                    else if (Math.Round(listOfMassivesX[j][listOfMassivesX[j].Count() - 1], 2) == Math.Round(massivesForPolygonX[i][massivesForPolygonX[i].Count() - 1], 2) &&
                        Math.Round(listOfMassivesY[j][listOfMassivesY[j].Count() - 1], 2) == Math.Round(massivesForPolygonY[i][massivesForPolygonY[i].Count() - 1], 2))
                    {
                        massivesForPolygonX.Add(reversedArray(listOfMassivesX[j]));
                        listOfMassivesX.Remove(listOfMassivesX[j]);

                        massivesForPolygonY.Add(reversedArray(listOfMassivesY[j]));
                        listOfMassivesY.Remove(listOfMassivesY[j]);
                        break;
                    }
                }
            }
            // Объединяем массивы, заливая их в новый unitedMassives
            double[] unitedMassiveX = uniteMassives(massivesForPolygonX);
            double[] unitedMassiveY = uniteMassives(massivesForPolygonY);

            return new List<double[]> { unitedMassiveX, unitedMassiveY };
        }

        // Метод для объединения массивов 2.0
        public double[] uniteMassives(List<double[]> massivesForUnion)
        {
            var unitedMassives = new double[] { };
            unitedMassives = unitedMassives.Concat(massivesForUnion[0]).ToArray();
            for (int i = 1; i < massivesForUnion.Count(); i++)
            {
                unitedMassives = unitedMassives.Concat(massivesForUnion[i]).ToArray();
            }
            return unitedMassives;
        }

        // Метод для разворота массивов
        public double[] reversedArray(double[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                double tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }
            return array;
        }

        private void buildingReadyPoints(List<double[]> listOfMassivesX, List<double[]> listOfMassivesY)
        {
            for (int i=0; i<listOfMassivesX.Count(); i++)
            {
                formsPlot1.plt.PlotScatter(listOfMassivesX[i], listOfMassivesY[i], color: Color.Black,
                    lineWidth: 5, markerSize: 0);
                formsPlot1.Render();
            }
        }
    }
}