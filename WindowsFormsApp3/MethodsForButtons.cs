using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class MethodsForButtons
    {
        // Метод для заливки областей определённым цветом
        public void fillArea(Color fillColor, FormsPlot formsPlot, TextBox nameOfDiagram)
        {
            double X01, Y01, X11, Y11, X31, Y31;
            double X02, Y02, X12, Y12, X32, Y32;
            double X03, Y03, X33, Y33;
            double X04, Y04, X34, Y34;
            X01 = getPointFromDB("X0", 1, nameOfDiagram);
            Y01 = getPointFromDB("Y0", 1, nameOfDiagram);
            X11 = getPointFromDB("X1", 1, nameOfDiagram);
            Y11 = getPointFromDB("Y1", 1, nameOfDiagram);
            X31 = getPointFromDB("X3", 1, nameOfDiagram);
            Y31 = getPointFromDB("Y3", 1, nameOfDiagram);

            X02 = getPointFromDB("X0", 2, nameOfDiagram);
            Y02 = getPointFromDB("Y0", 2, nameOfDiagram);
            X12 = getPointFromDB("X1", 2, nameOfDiagram);
            Y12 = getPointFromDB("Y1", 2, nameOfDiagram);
            X32 = getPointFromDB("X3", 2, nameOfDiagram);
            Y32 = getPointFromDB("Y3", 2, nameOfDiagram);

            X03 = getPointFromDB("X0", 3, nameOfDiagram);
            Y03 = getPointFromDB("Y0", 3, nameOfDiagram);
            X33 = getPointFromDB("X3", 3, nameOfDiagram);
            Y33 = getPointFromDB("Y3", 3, nameOfDiagram);

            X04 = getPointFromDB("X0", 4, nameOfDiagram);
            Y04 = getPointFromDB("Y0", 4, nameOfDiagram);
            X34 = getPointFromDB("X3", 4, nameOfDiagram);
            Y34 = getPointFromDB("Y3", 4, nameOfDiagram);

            double[] thirdY = reversedArray(bezierMassives(X03, Y03, X33, Y33)[1]);
            double[] secondY = reversedArray(bezierMassives(X02, Y02, X12, Y12, X32, Y32)[1]);

            double[] thirdX = reversedArray(bezierMassives(X03, Y03, X33, Y33)[0]);
            double[] secondX = reversedArray(bezierMassives(X02, Y02, X12, Y12, X32, Y32)[0]);

            formsPlot.plt.PlotPolygon(
                xs: UnionArrays(UnionArrays(UnionArrays(bezierMassives(X01, Y01, X11, Y11, X31, Y31)[0], thirdX), secondX),
                bezierMassives(X04, Y04, X34, Y34)[0]),
                ys: UnionArrays(UnionArrays(UnionArrays(bezierMassives(X01, Y01, X11, Y11, X31, Y31)[1], thirdY), secondY),
                bezierMassives(X04, Y04, X34, Y34)[1]),
                lineWidth: 2,
                fillAlpha: .4,
                fillColor: Color.Aqua,
                lineColor: Color.Black);

            formsPlot.plt.PlotText("demo text", 1, 1300,
                fontName: "comic sans ms",
                fontSize: 42,
                color: fillColor,
                bold: true);
        }

        public void fillAreas(FormsPlot formsPlot, TextBox nameOfDiagram)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            sqlConnection.Open();

            double X0, Y0, X1, Y1, X2, Y2, X3, Y3;
            var oneAreaMassives = new List<double[]> { };
            var listOfBezierMassives = new List<double[]> { };
            var massivesX = new List<double[]> { };
            var massivesY = new List<double[]> { };
            var massivesForPolygonX = new List<double[]> { };


            string queryForGettingPoints = string.Format("SELECT MAX(NumberOfColorGroup1) FROM [{0}]", nameOfDiagram.Text.Replace("-", ""));
            SqlCommand commandForCount = new SqlCommand(queryForGettingPoints, sqlConnection);
            int numberOfAreas = (int)commandForCount.ExecuteScalar();

            // Перебор областей, то есть групп
            for (int i = 1; i <= numberOfAreas; i++)
            {
                oneAreaMassives.Clear();
                listOfBezierMassives.Clear();
                massivesX.Clear();
                massivesY.Clear();
                massivesForPolygonX.Clear();
                // Считаем, сколько строк принадлежат одной группе
                string queryForCountOneGroupRows = string.Format("SELECT COUNT(*) FROM [{0}] WHERE NumberOfColorGroup1 = {1}" +
                    " OR NumberOfColorGroup2 = {1}", nameOfDiagram.Text.Replace("-", ""), i);
                SqlCommand commandForCountOneGroupRows = new SqlCommand(queryForCountOneGroupRows, sqlConnection);
                int numberOfOneGroupRows = (int)commandForCountOneGroupRows.ExecuteScalar();

                // Перебор строк в одной области
                for(int j = 0; j < numberOfOneGroupRows; j++)
                {
                    X0 = getPointFromDB("X0", i, nameOfDiagram);
                    Y0 = getPointFromDB("Y0", i, nameOfDiagram);
                    X1 = getPointFromDB("X1", i, nameOfDiagram);
                    Y1 = getPointFromDB("Y1", i, nameOfDiagram);
                    X2 = getPointFromDB("X2", i, nameOfDiagram);
                    Y2 = getPointFromDB("Y2", i, nameOfDiagram);
                    X3 = getPointFromDB("X3", i, nameOfDiagram);
                    Y3 = getPointFromDB("Y3", i, nameOfDiagram);

                    if (X1 == -300 && X2 == -300)
                    {
                        listOfBezierMassives = bezierMassives(X0, Y0, X3, Y3);
                        massivesX.Add(listOfBezierMassives[0]);
                        massivesY.Add(listOfBezierMassives[1]);
                    }
                    else if (X1 != -300 && X2 == -300)
                    {
                        listOfBezierMassives = bezierMassives(X0, Y0, X1, Y1, X3, Y3);
                        massivesX.Add(listOfBezierMassives[0]);
                        massivesY.Add(listOfBezierMassives[1]);
                    }
                }
                formsPlot.plt.PlotPolygon(
                        xs: massiveSorting(massivesX),
                        ys: massiveSorting(massivesY),
                        lineWidth: 2,
                        fillAlpha: .5,
                        lineColor: Color.Black);
                formsPlot.plt.Axis(0, 7, 600, 1600);
                // Сортируем массивы так, чтобы можно было построить полигон
                //try
                //{
                //    formsPlot.plt.PlotPolygon(
                //        xs: massiveSorting(massivesX),
                //        ys: massiveSorting(massivesY),
                //        lineWidth: 2,
                //        fillAlpha: .5,
                //        lineColor: Color.Black);
                //}
                //catch (Exception)
                //{

                //}
            }
            
            //x.Add(bezierMassives(1, 2, 3, 4)[0]);
            //x.Add(bezierMassives(1, 2, 3, 4)[1]);
            
        }

        // Метод сортировки и объединения массивов
        public double[] massiveSorting(List<double[]> listOfMassives)
        {
            var massivesForPolygon = new List<double[]> { };

            massivesForPolygon.Add(listOfMassives[0]);
            listOfMassives.RemoveAt(0);
            int listLength = listOfMassives.Count();
            for (int i = 0; i < listLength; i++)
            {
                for (int j = 0; j < listOfMassives.Count(); j++)
                {
                    if (listOfMassives[j][0] == massivesForPolygon[massivesForPolygon.Count() - 1]
                        [massivesForPolygon[massivesForPolygon.Count() - 1].Count() - 1])
                    {
                        massivesForPolygon.Add(listOfMassives[j]);
                        listOfMassives.Remove(listOfMassives[j]);
                        break;
                    }
                    else if (listOfMassives[j][listOfMassives[j].Count() - 1] == massivesForPolygon[massivesForPolygon.Count() - 1]
                        [massivesForPolygon[massivesForPolygon.Count() - 1].Count() - 1])
                    {
                        massivesForPolygon.Add(reversedArray(listOfMassives[j]));
                        listOfMassives.Remove(listOfMassives[j]);
                        break;
                    }
                }
            }
            // Обхединяем массивы, заливая их в новый unitedMassives
            var unitedMassives = new double[] { };
            unitedMassives.CopyTo(massivesForPolygon[0], 0);
            for (int i = 1; i < massivesForPolygon.Count(); i++)
            {
                unitedMassives.CopyTo(massivesForPolygon[i], unitedMassives.Length);
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

        // Метод для объединения массивов
        public double[] UnionArrays(double[] days, double[] months)
        {
            var daysAndMonths = new double[days.Length + months.Length];
            for (var i = 0; i < days.Length; i++)
                daysAndMonths[i] = days[i];
            for (var i = 0; i < months.Length; i++)
                daysAndMonths[days.Length + i] = months[i];
            return daysAndMonths;
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

        // Метод для получения точки из БД
        public double getPointFromDB(string nameOfPoint, int id, TextBox nameOfDiagram)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            sqlConnection.Open();
            string queryForGettingPoint = string.Format("SELECT {0} FROM {1} WHERE NumberOfColorGroup1 = {2}" +
                " OR NumberOfColorGroup2 = {2}", nameOfPoint, nameOfDiagram.Text.Replace("-", ""), id);
            SqlCommand commandForGettingPoint = new SqlCommand(queryForGettingPoint, sqlConnection);
            return (double)commandForGettingPoint.ExecuteScalar();
        }
    }
}
