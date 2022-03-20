using System;
using System.Collections;
using System.Collections.Generic;

namespace PackingAndUnpacking
{
    public class PackingUnpackingService
    {
        //точка с координатами
        struct Point {
            public int x, y;
        }

        public void MethodExecute()
        {
            //значимый тип, выделилось место в стеке
            Point pointStruct;

            //ссылочный тип, выделилось место в куче
            List<int> listOfInt = new List<int>();
            Dictionary<int, int> listOfPoint = new Dictionary<int, int>();
            ArrayList arrayOfObject = new ArrayList();
            
            
            
            for (var i = 1; i <= 10; i++)
            {
                //1,1;2,2;...
                pointStruct.x = pointStruct.y = i;
                
                //упаковка - объект типа Point из стека переехал в кучу
                
                //одно значение
                listOfInt.Add(pointStruct.x);
                //два значения
                listOfPoint.Add(pointStruct.x, pointStruct.y);
                //упаковали целиком структуру
                arrayOfObject.Add(pointStruct);
            }
            
            //cast - приведение к типу
            var intNub = (int)10; //cast to Int
            
            //распаковка - объект из arrayOfObject переехал в стек в структуру pointFromArray
            Point pointFromArray = (Point) arrayOfObject[0]; //cast to Point
            
            //получаем объект неявно
            Point pointFromArray2 = GetPoint(arrayOfObject[0]); //cast to Point

            
            //as - проверить, можно ли распаковать и вернуть значение, если можно, а если нельзя - вернуть NULL
            object s = "jkjl";
            // string s2;
            // if (s is string)
            // {
            //     s2 = (string)s;
            // }
            // else
            // {
            //     s2 = null;
            // }
            string s2 = s as string;

            object sWrong = new int[] {1, 2, 3};
            string s3 = sWrong as string; // будет NULL, тк класс Weapon в строку преобразовать нельзя
            
            if (s3 is null)
            {
                //
            }

            int? value = 123134;
            value = arrayOfObject[0] as int?;
            if (value is null)
            {
                //
            }
            
        }

        private void Method1()
        {
            var x = GetPoint(1);
        }
        
        //если передадим НЕ переменную типа Point - будут проблемки
        private Point GetPoint(object point)
        {
            Point pointResult = (Point)point;
            return pointResult;
        }

        
        // Метод с оператором is - проблемы отлавливаем
        private Point GetPointWithoutProblems(object point)
        {
            Point pointResult;
            if (point is Point)
            {
                pointResult = (Point)point; //cast to Point
            }
            else
            {
                throw new InvalidCastException();
            }

            return new Point()
            {
                x = pointResult.x / 10,
                y = pointResult.x / pointResult.y
            };
        }

        //try - catch 
        // в случае проблем - бросаем КОНТРОЛИРУЕМОЕ исключение
        private Point GetPointWithControlledException(object point)
        {
            try
            {   
                Point pointFromArray = (Point)point; //cast to Point
                var result = new Point()
                {
                    x = pointFromArray.x / 10,
                    y = pointFromArray.x / pointFromArray.y
                };

                return pointFromArray;
            }
            catch (InvalidCastException ex)
            {
                return new Point();
                //logger.LogWarning("не удалось превратить объект в точку");
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
        }
    }
}