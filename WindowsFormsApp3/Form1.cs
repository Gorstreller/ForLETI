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
            /*if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение установлено!");
            }*/
        }

        // Нажатие на кнопку "Просто по точкам"
        private void button1_Click(object sender, EventArgs e)
        {
            double[] dataX_AB = new double[] { 0, 0.16, 0.25, 0.39, 0.51 };
            double[] dataY_AB = new double[] { 1539, 1530, 1523, 1512, 1499 };
            double[] dataX_BC = new double[] { 0.51, 1.5, 2, 3, 4.3 };
            double[] dataY_BC = new double[] { 1499, 1450, 1415, 1308, 1147 };
            double[] dataX_CD = new double[] { 4.3, 4.5, 5, 5.5, 6, 6.67 };
            double[] dataY_CD = new double[] { 1147, 1225, 1344, 1437, 1519, 1600 };
            double[] dataX_DL = new double[] { 6.67, 6.67 };
            double[] dataY_DL = new double[] { 1600, 600 };
            double[] dataX_AH = new double[] { 0, 0.1 };
            double[] dataY_AH = new double[] { 1539, 1499 };
            double[] dataX_HB = new double[] { 0.1, 0.51 };
            double[] dataY_HB = new double[] { 1499, 1499 };
            double[] dataX_EF = new double[] { 2.14, 6.67 };
            double[] dataY_EF = new double[] { 1147, 1147 };
            double[] dataX_NH = new double[] { 0, 0.05, 0.08, 0.095, 0.1 };
            double[] dataY_NH = new double[] { 1392, 1422, 1450, 1465, 1499 };
            double[] dataX_NJ = new double[] { 0, 0.1, 0.13, 0.15, 0.16 };
            double[] dataY_NJ = new double[] { 1392, 1425, 1450, 1480, 1499 };
            double[] dataX_JE = new double[] { 0.16, 0.5, 1, 1.5, 2.14 };
            double[] dataY_JE = new double[] { 1499, 1425, 1338, 1250, 1147 };
            double[] dataX_SE = new double[] { 0.8, 1.15, 1.42, 1.78, 2.14 };
            double[] dataY_SE = new double[] { 727, 850, 950, 1050, 1147 };
            double[] dataX_PK = new double[] { 0.2, 6.67 };
            double[] dataY_PK = new double[] { 727, 727 };
            double[] dataX_GS = new double[] { 0, 0.2, 0.4, 0.57, 0.8 };
            double[] dataY_GS = new double[] { 911, 850, 800, 768, 727 };
            double[] dataX_GP = new double[] { 0, 0.05, 0.1, 0.16, 0.2 };
            double[] dataY_GP = new double[] { 911, 850, 800, 750, 727 };
            double[] dataX_QP = new double[] { 0.05, 0.09, 0.15, 0.2 };
            double[] dataY_QP = new double[] { 600, 650, 700, 727 };
            formsPlot1.plt.PlotScatter(dataX_AB, dataY_AB, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_BC, dataY_BC, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_CD, dataY_CD, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_DL, dataY_DL, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_AH, dataY_AH, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_HB, dataY_HB, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_EF, dataY_EF, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_NH, dataY_NH, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_NJ, dataY_NJ, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_JE, dataY_JE, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_SE, dataY_SE, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_PK, dataY_PK, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_GS, dataY_GS, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_GP, dataY_GP, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_QP, dataY_QP, markerSize: 0, color: Color.Green);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            formsPlot1.Render();
        }

        // Метод для вывода координат мышки в текст-боксы
        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            OX.Text = Math.Round(mouseCoordX, 2).ToString();
            OY.Text = Math.Round(mouseCoordY, 2).ToString();
            //formsPlot1.Render();
        }

        // Нажатие на кнопку "Кубический сплайн"
        private void button2_Click(object sender, EventArgs e)
        {
            // Задаём координаты точек для построения
            float[] dataX_AB = new float[] { 0, 0.16f, 0.25f, 0.39f, 0.51f };
            float[] dataY_AB = new float[] { 1539, 1530, 1523, 1512, 1499 };
            float[] dataX_BC = new float[] { 0.51f, 1.5f, 2, 3, 4.3f };
            float[] dataY_BC = new float[] { 1499, 1450, 1415, 1308, 1147 };
            float[] dataX_CD = new float[] { 4.3f, 4.5f, 5, 5.5f, 6, 6.67f };
            float[] dataY_CD = new float[] { 1147, 1225, 1344, 1437, 1519, 1600 };
            double[] dataX_DL = new double[] { 6.67, 6.67 };
            double[] dataY_DL = new double[] { 1600, 600 };
            float[] dataX_AH = new float[] { 0, 0.1f };
            float[] dataY_AH = new float[] { 1539, 1499 };
            double[] dataX_HB = new double[] { 0.1, 0.51 };
            double[] dataY_HB = new double[] { 1499, 1499 };
            double[] dataX_EF = new double[] { 2.14, 6.67 };
            double[] dataY_EF = new double[] { 1147, 1147 };
            float[] dataX_NH = new float[] { 0, 0.05f, 0.08f, 0.095f, 0.1f };
            float[] dataY_NH = new float[] { 1392, 1422, 1450, 1465, 1499 };
            float[] dataX_NJ = new float[] { 0, 0.1f, 0.13f, 0.15f, 0.16f };
            float[] dataY_NJ = new float[] { 1392, 1425, 1450, 1480, 1499 };
            float[] dataX_JE = new float[] { 0.16f, 0.5f, 1, 1.5f, 2.14f };
            float[] dataY_JE = new float[] { 1499, 1425, 1338, 1250, 1147 };
            float[] dataX_SE = new float[] { 0.8f, 1.15f, 1.42f, 1.78f, 2.14f };
            float[] dataY_SE = new float[] { 727, 850, 950, 1050, 1147 };
            double[] dataX_PK = new double[] { 0.2, 6.67 };
            double[] dataY_PK = new double[] { 727, 727 };
            float[] dataX_GS = new float[] { 0, 0.2f, 0.4f, 0.57f, 0.8f };
            float[] dataY_GS = new float[] { 911, 850, 800, 768, 727 };
            float[] dataX_GP = new float[] { 0, 0.05f, 0.1f, 0.16f, 0.2f };
            float[] dataY_GP = new float[] { 911, 850, 800, 750, 727 };
            float[] dataX_QP = new float[] { 0.05f, 0.09f, 0.15f, 0.2f };
            float[] dataY_QP = new float[] { 600, 650, 700, 727 };
            // Объявляем промежуточные переменные для применения метода FitParametric()
            float[] dataX_AB_float, dataY_AB_float,
                dataX_BC_float, dataY_BC_float,
                dataX_CD_float, dataY_CD_float,
                dataX_AH_float, dataY_AH_float,
                dataX_NH_float, dataY_NH_float,
                dataX_NJ_float, dataY_NJ_float,
                dataX_JE_float, dataY_JE_float,
                dataX_SE_float, dataY_SE_float,
                dataX_GS_float, dataY_GS_float,
                dataX_GP_float, dataY_GP_float,
                dataX_QP_float, dataY_QP_float;
            CubicSpline.FitParametric(dataX_AB, dataY_AB, 100, out dataX_AB_float, out dataY_AB_float);
            CubicSpline.FitParametric(dataX_BC, dataY_BC, 100, out dataX_BC_float, out dataY_BC_float);
            CubicSpline.FitParametric(dataX_CD, dataY_CD, 100, out dataX_CD_float, out dataY_CD_float);
            CubicSpline.FitParametric(dataX_AH, dataY_AH, 100, out dataX_AH_float, out dataY_AH_float);
            CubicSpline.FitParametric(dataX_NH, dataY_NH, 100, out dataX_NH_float, out dataY_NH_float);
            CubicSpline.FitParametric(dataX_NJ, dataY_NJ, 100, out dataX_NJ_float, out dataY_NJ_float);
            CubicSpline.FitParametric(dataX_JE, dataY_JE, 100, out dataX_JE_float, out dataY_JE_float);
            CubicSpline.FitParametric(dataX_SE, dataY_SE, 100, out dataX_SE_float, out dataY_SE_float);
            CubicSpline.FitParametric(dataX_GS, dataY_GS, 100, out dataX_GS_float, out dataY_GS_float);
            CubicSpline.FitParametric(dataX_GP, dataY_GP, 100, out dataX_GP_float, out dataY_GP_float);
            CubicSpline.FitParametric(dataX_QP, dataY_QP, 100, out dataX_QP_float, out dataY_QP_float);
            // Переводим все массивы из float в double
            double[] dataX_AB_double = Array.ConvertAll(dataX_AB_float, u => (double)u);
            double[] dataY_AB_double = Array.ConvertAll(dataY_AB_float, u => (double)u);
            double[] dataX_BC_double = Array.ConvertAll(dataX_BC_float, u => (double)u);
            double[] dataY_BC_double = Array.ConvertAll(dataY_BC_float, u => (double)u);
            double[] dataX_CD_double = Array.ConvertAll(dataX_CD_float, u => (double)u);
            double[] dataY_CD_double = Array.ConvertAll(dataY_CD_float, u => (double)u);
            double[] dataX_AH_double = Array.ConvertAll(dataX_AH_float, u => (double)u);
            double[] dataY_AH_double = Array.ConvertAll(dataY_AH_float, u => (double)u);
            double[] dataX_NH_double = Array.ConvertAll(dataX_NH_float, u => (double)u);
            double[] dataY_NH_double = Array.ConvertAll(dataY_NH_float, u => (double)u);
            double[] dataX_NJ_double = Array.ConvertAll(dataX_NJ_float, u => (double)u);
            double[] dataY_NJ_double = Array.ConvertAll(dataY_NJ_float, u => (double)u);
            double[] dataX_JE_double = Array.ConvertAll(dataX_JE_float, u => (double)u);
            double[] dataY_JE_double = Array.ConvertAll(dataY_JE_float, u => (double)u);
            double[] dataX_SE_double = Array.ConvertAll(dataX_SE_float, u => (double)u);
            double[] dataY_SE_double = Array.ConvertAll(dataY_SE_float, u => (double)u);
            double[] dataX_GS_double = Array.ConvertAll(dataX_GS_float, u => (double)u);
            double[] dataY_GS_double = Array.ConvertAll(dataY_GS_float, u => (double)u);
            double[] dataX_GP_double = Array.ConvertAll(dataX_GP_float, u => (double)u);
            double[] dataY_GP_double = Array.ConvertAll(dataY_GP_float, u => (double)u);
            double[] dataX_QP_double = Array.ConvertAll(dataX_QP_float, u => (double)u);
            double[] dataY_QP_double = Array.ConvertAll(dataY_QP_float, u => (double)u);
            // Строим всё это безобразие
            formsPlot1.plt.PlotScatter(dataX_AB_double, dataY_AB_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_BC_double, dataY_BC_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_CD_double, dataY_CD_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_AH_double, dataY_AH_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_NH_double, dataY_NH_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_NJ_double, dataY_NJ_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_JE_double, dataY_JE_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_SE_double, dataY_SE_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_GS_double, dataY_GS_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_GP_double, dataY_GP_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_QP_double, dataY_QP_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            formsPlot1.Render();
        }

        // Нажатие на кнопку "Очистить"
        private void clearPlotButton_Click(object sender, EventArgs e)
        {
            formsPlot1.plt.Clear();
            formsPlot1.Render();
        }

        // Нажатие на кнопку "Безье"
        private void mainBuildingButton_Click(object sender, EventArgs e)
        {
            bezierBuilding();
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

        // МЕТОД НА УДАЛЕНИЕ!!!
        // Перегрузка построения по Безье без параметров
        private void bezierBuilding()
        {
            double P0x, P1xBefore, P3x, P0y, Py, P3y;
            if (double.TryParse(this.P0x.Text, out P0x) &&
                double.TryParse(this.P0y.Text, out P0y) &&
                double.TryParse(this.P1x.Text, out P1xBefore) &&
                double.TryParse(this.P1y.Text, out Py) &&
                double.TryParse(this.P2x.Text, out P3x) &&
                double.TryParse(this.P2y.Text, out P3y))
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
                        formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Black, markerSize: 2);
                        formsPlot1.plt.Axis(0, 7, 600, 1600);
                        formsPlot1.plt.AxisBounds(0, 7, 600, 1600);
                        formsPlot1.Render();
                        break;
                    }
                }
            }
            else
            {
                x0.Text = "Вы ввели неверное значение!";
            }
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
            //string queryForGettingPoints = string.Format("SELECT MAX(NumberOfColorGroup2) FROM [{0}]", nameOfDiagram.Text.Replace("-", ""));
            //SqlCommand commandForCount = new SqlCommand(queryForGettingPoints, sqlConnection);
            //int count = (int)commandForCount.ExecuteScalar();

            //double X0, Y0, X1, Y1, X2, Y2, X3, Y3;
            //List<double[]> listOfBezierMassives;
            //List<double[]> massivesX = new List<double[]> { };
            //List<double[]> massivesY = new List<double[]> { };

            ////new MethodsForButtons().fillArea(Color.Magenta, formsPlot1, nameOfDiagram);

            //for (int i = 1; i <= count; i++)
            //{
            //    X0 = getPointFromDB("X0", i);
            //    Y0 = getPointFromDB("Y0", i);
            //    X1 = getPointFromDB("X1", i);
            //    Y1 = getPointFromDB("Y1", i);
            //    X2 = getPointFromDB("X2", i);
            //    Y2 = getPointFromDB("Y2", i);
            //    X3 = getPointFromDB("X3", i);
            //    Y3 = getPointFromDB("Y3", i);

            //    if (X1 == -300 && X2 == -300)
            //    {
            //        listOfBezierMassives = bezierBuilding(X0, Y0, X3, Y3);
            //        massivesX.Add(listOfBezierMassives[0]);
            //        massivesY.Add(listOfBezierMassives[1]);
            //    }
            //    else if (X1 != -300 && X2 == -300)
            //    {
            //        listOfBezierMassives = bezierBuilding(X0, Y0, X1, Y1, X3, Y3);
            //        massivesX.Add(listOfBezierMassives[0]);
            //        massivesY.Add(listOfBezierMassives[1]);
            //    }
            //    else
            //    {
            //        listOfBezierMassives = bezierBuilding(X0, Y0, X1, Y1, X2, Y2, X3, Y3);
            //        massivesX.Add(listOfBezierMassives[0]);
            //        massivesY.Add(listOfBezierMassives[1]);
            //    }
            //}
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


            string queryForGettingPoints = string.Format("SELECT MAX(NumberOfColorGroup1) FROM [{0}]", nameOfDiagram.Text.Replace("-", ""));
            SqlCommand commandForCount = new SqlCommand(queryForGettingPoints, sqlConnection);
            int numberOfAreas = (int)commandForCount.ExecuteScalar();

            // Перебор областей, то есть групп
            for (int i = 1; i <= numberOfAreas; i++)
            {
                //oneAreaMassives.Clear();
                //listOfBezierMassives.Clear();
                //massivesX.Clear();
                //massivesY.Clear();
                //massivesForPolygonX.Clear();
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

            //x.Add(bezierMassives(1, 2, 3, 4)[0]);
            //x.Add(bezierMassives(1, 2, 3, 4)[1]);

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