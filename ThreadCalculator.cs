namespace ProgrammingTechnologiesLaboratoryWork6_1;

public delegate void ThreadCallBack(string startTimeOfProcess, string finishTimeOfProcess, string durationOfProcess, int currentThreadId, int progressBarValue);

public class ThreadCalculator(int threadId, int minX, int maxX, int minY, int maxY, int sizeOfArrays, ThreadCallBack callback)
{
    private readonly double _minX = minX * threadId;
    private readonly double _maxX = maxX * threadId;
    private readonly double _minY = minY * threadId;
    private readonly double _maxY = maxY * threadId;
    private DateTime _startTime;

    private double[] _arrayOfArgumentsX = null!;
    private double[] _arrayOfArgumentsY = null!;
    private double[,] _arrayOfValuesZ = null!;

    private double _stepX;
    private double _stepY;

    private static readonly object _lockObject = new();

    public void ThreadDoWork()
    {
        _startTime = DateTime.Now;

        CreateArrays();
        FillArgumentsArrays();
        CalculateVariantFunction();

        lock (_lockObject)
        {
            PrintToFile();
            SendCallback();
        }
    }

    private void SendCallback()
    {
        DateTime finishTime = DateTime.Now;
        string startTimeString = $"{_startTime:HH:mm:ss}.{_startTime.Millisecond}";
        string finishTimeString = $"{finishTime:HH:mm:ss}.{finishTime.Millisecond}";
        string durationOfProcess = (finishTime - _startTime).ToString();

        callback(startTimeString, finishTimeString, durationOfProcess, threadId, 49);
    }

    private void CreateArrays()
    {
        _arrayOfValuesZ = new double[sizeOfArrays, sizeOfArrays];
        _arrayOfArgumentsX = new double[sizeOfArrays];
        _arrayOfArgumentsY = new double[sizeOfArrays];
    }

    private void FillArgumentsArrays()
    {
        _stepX = (_maxX - _minX) / (sizeOfArrays - 1);
        _stepY = (_maxY - _minY) / (sizeOfArrays - 1);

        for (int i = 0; i < sizeOfArrays; i++)
        {
            _arrayOfArgumentsX[i] = _minX + _stepX * i;
            _arrayOfArgumentsY[i] = _minY + _stepY * i;
        }
    }

    private void CalculateVariantFunction()
    {
        for (int i = 0; i < sizeOfArrays; i++)
        {
            for (int j = 0; j < sizeOfArrays; j++)
            {
                _arrayOfValuesZ[i, j] = Function13(_arrayOfArgumentsX[i], _arrayOfArgumentsY[j]);
            }
        }
    }

    private void PrintToFile()
    {
        string fileName = @"C:\Save\resultsDll.txt";
        using StreamWriter writer = File.AppendText(fileName);

        for (int i = 0; i < sizeOfArrays; i++)
        {
            string line = string.Empty;
            for (int j = 0; j < sizeOfArrays; j++)
            {
                line += $"Z[{i}][{j}] = {_arrayOfValuesZ[i, j]}; ";
            }
            writer.WriteLine(line);
        }

        DateTime finishTime = DateTime.Now;
        writer.WriteLine();
        writer.WriteLine($"Поток номер - {threadId}; Время - {finishTime:HH:mm:ss}.{finishTime.Millisecond};");
        writer.WriteLine();
        writer.WriteLine();
    }

    private static double Function13(double x, double y)
    {
        return (Math.Exp(x) * (Math.Sin(y) - Math.Pow(Math.Cos(y), 2))) / (Math.Pow(Math.Sin(x), 2) + Math.Cos(x));
    }
} 