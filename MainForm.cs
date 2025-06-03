namespace ProgrammingTechnologiesLaboratoryWork6_1;

public partial class MainForm : Form
{
    private const int NumberOfThreads = 4;

    private string StartTimeOfProcess { get; set; } = string.Empty;
    private string FinishTimeOfProcess { get; set; } = string.Empty;
    private string DurationOfProcess { get; set; } = string.Empty;
    private int CurrentThreadId { get; set; }
    private int ProgressBarValue { get; set; }

    public MainForm()
    {
        InitializeComponent();
        StartThreadCalculations();
    }

    private void StartThreadCalculations()
    {
        Thread[] threads = new Thread[NumberOfThreads];
        for (int i = 0; i < NumberOfThreads; i++) {
            int threadId = i + 1;
            var calculator = new ThreadCalculator(threadId, minX: 1, maxX: 10, minY: 1, maxY: 10, sizeOfArrays: 100, callback: ChangeComponent);

            threads[i] = new(calculator.ThreadDoWork);
            threads[i].Start();
        }
    }

    private void ChangeComponent(string startTime, string finishTime, string duration, int threadId, int progressValue)
    {
        if (InvokeRequired) {
            Invoke(() => ChangeComponent(startTime, finishTime, duration, threadId, progressValue));
            return;
        }

        StartTimeOfProcess = startTime;
        FinishTimeOfProcess = finishTime;
        DurationOfProcess = duration;
        CurrentThreadId = threadId;
        ProgressBarValue = progressValue;
        UpdateUI();
    }

    private void UpdateUI()
    {
        labelStartTime.Text = StartTimeOfProcess;
        labelFinishTime.Text = FinishTimeOfProcess;
        labelDuration.Text = DurationOfProcess;
        labelThreadId.Text = CurrentThreadId.ToString();
        progressBar.Value = ProgressBarValue;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        UpdateUI();
    }
}