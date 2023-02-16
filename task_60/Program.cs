// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


bool vertificationNumber(int[] savedNumbers, int check)
        {
            int count = 0;
            for (int i = 0; i < savedNumbers.Length; i++)
            {
                if(savedNumbers[i] == check)
                {
                    count ++;
                }
            }
            if(count > 1) return false;
            else return true;
        }

        Console.Write("Enter x: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y: ");
        int y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter z: ");
        int z = Convert.ToInt32(Console.ReadLine());
        int[,,] array60 = new int[x, y, z];
        int[] savedNums = new int[x*y*z];

        for (int i = 0; i < array60.GetLength(0); i++)
        {
            for (int j = 0; j < array60.GetLength(1); j++)
            {
                for (int k = 0; k < array60.GetLength(2); k++)
                {
                    array60[i, j, k] = new Random().Next(10, 100);

                    int num = array60[i, j, k];

                    for (int m = 0; m < savedNums.Length; m++)
                    {
                        if(savedNums[m] != num && savedNums[m] == 0) 
                        {
                            savedNums[m] = num;
                            break;
                        }
                    }
                    
                    bool isOk = vertificationNumber(savedNums, num);

                    if(isOk == false)
                    {
                        while(isOk == false)
                        {
                            isOk = true;
                            array60[i, j, k] = new Random().Next(10, 100);
                            num = array60[i, j, k];
                            for (int m = 0; m < savedNums.Length; m++)
                            {
                                if(savedNums[m] != num && savedNums[m] == 0)
                                {
                                        savedNums[m] = num;
                                        break;
                                }
                                else
                                {
                                    isOk = false;
                                    break;
                                }
                            }
                            if(isOk == true) vertificationNumber(savedNums, num);
                        }
                    }

                    Console.Write(array60[i, j, k] + $"({i}, {j}, {k}) ");
                }
            Console.WriteLine();
            }
        }