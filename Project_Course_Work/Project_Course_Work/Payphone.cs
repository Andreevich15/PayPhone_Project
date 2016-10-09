using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using NAudio;

namespace Project_Course_Work
{
    public delegate void CardLimit(double data);

    public partial class Payphone : Form
    {
        public Payphone()
        {
            InitializeComponent();
        }
        TeamsJournal Journal_event;
        delegate void JournalEvents(object source, ListHandlerEventArgs args);
        static event JournalEvents message;

        private void MessageEvent(DateTime Start, DateTime Stop, string time, TeamsJournal f_journal)
        {
            message += f_journal.NewEvents;
        }

        private void Payphone_Load(object sender, EventArgs e)
        {
            Journal_event = new TeamsJournal();
            MessageEvent(Start, DateTime.Now, time, Journal_event);
        }

        Tube_Payphone TubePayphone = new Tube_Payphone();
        Display_Message DisplayMessage = new Display_Message();
        Receiver_Card ReceiverCard = new Receiver_Card();

        DateTime Start;
        string time;

        private void Tube_Click(object sender, EventArgs e)
        {
            if (TubePayphone.check_removal_tube == false)
            {
                TubePayphone.check_removal_tube = true;
                if (ReceiverCard.check_on_insert_card == false)
                {
                    CardReader.Enabled = true;
                    Display.Text = DisplayMessage.Start_Message();
                }
            }
            else
            {
                Complete_talk();
                if (!ReceiverCard.check_on_insert_card) Display.Clear();
                TubePayphone.check_removal_tube = false;
            }
        }

        private void CardReader_Click(object sender, EventArgs e)
        {
            if (!ReceiverCard.check_on_insert_card)
            {
                Display.Text = DisplayMessage.Start_Message();
                ReceiverCardForm form2 = new ReceiverCardForm(new CardLimit(func_for_read_card));
                form2.Show();
                ReceiverCard.check_on_insert_card = true;
            }
            else
            {
                Complete_talk();
                ReceiverCard.check_on_insert_card = false;
                if (TubePayphone.check_removal_tube)
                {
                    Display.Text = "Карта вынута!";
                }
                else
                {
                    Display.Clear();
                    CardReader.Enabled = false;
                }
            }
        }

        private void Complete_talk()
        {
            time = "1";
            if (waveIn != null && message != null && time != null)
            {
                StopRecording();
                Display.Text = DisplayMessage.Talk_Complete();
                timer.Stop();
                TimeSpan Res = DateTime.Now - Start;
                time = Res.Hours + ":" + Res.Minutes + ":" + Res.Seconds + ":" + Res.Milliseconds;
                Display.AppendText(" Лимит карты: " + ReceiverCard.card_limit);
                Display.AppendText(" Выньте карту!");
                message(this, new ListHandlerEventArgs(Start, DateTime.Now, time));
            }
        }
        void func_for_read_card(double param)
        {
            if (ReceiverCard.check_suitability_card())
            {
                ReceiverCard.card_limit = param;

                Display.Text = DisplayMessage.Ready_and_card_limit(ReceiverCard.card_limit) + '\n';
                TubePayphone.Play_sound_from_ATS(TubePayphone.generate_signal_from_ATS());
                if (TubePayphone.signal_from_ATS)
                {
                    Display.AppendText("Введите номер!");
                    phone = "";
                    Keyboard.Enabled = true;
                    CardReader.Enabled = false;
                }
                else
                {
                    Display.Text = "Линия занята!";
                    Display.AppendText(" Выньте карту!");
                }
            }
            else
            {
                Display.Text = DisplayMessage.For_crashed_card();
                Display.AppendText(" Выньте карту!");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            using (var news = new StreamWriter("Call_journal.txt", false))
            {
                news.Write(Journal_event.Information());
            }
            Journal currentEvents = new Journal();
            currentEvents.ShowDialog();
        }

        string phone;

        private void Press1_Click(object sender, EventArgs e)
        {
            phone += Press1.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press2_Click(object sender, EventArgs e)
        {
            phone += Press2.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press3_Click(object sender, EventArgs e)
        {
            phone += Press3.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press4_Click(object sender, EventArgs e)
        {
            phone += Press4.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press5_Click(object sender, EventArgs e)
        {
            phone += Press5.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press6_Click(object sender, EventArgs e)
        {
            phone += Press6.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press7_Click(object sender, EventArgs e)
        {
            phone += Press7.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press8_Click(object sender, EventArgs e)
        {
            phone += Press8.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press9_Click(object sender, EventArgs e)
        {
            phone += Press9.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press_star_Click(object sender, EventArgs e)
        {
            phone += Press_star.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press0_Click(object sender, EventArgs e)
        {
            phone += Press0.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        private void Press_diez_Click(object sender, EventArgs e)
        {
            phone += Press_diez.Text;
            Display.Text = "Введенный номер: \n" + phone;
        }

        Timer timer = new Timer();
        Timer for_card = new Timer();

        private void Start_timer_card()
        {
            for_card.Interval = 6000;
            for_card.Tick += new EventHandler(tickTimerCard);
            for_card.Start();
        }

        private void tickTimerCard(object sender, EventArgs e)
        {
            ReceiverCard.card_limit = ReceiverCard.card_limit - 0.1;
        }

        private void Start_timer()
        {
            Start = DateTime.Now;
            timer.Interval = 10;
            timer.Tick += new EventHandler(tickTimer);
            timer.Start();
        }

        private void tickTimer(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - Start.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            Display.Text = "Введенный номер: \n" + phone + "  Идет разговор! " + String.Format("{0:HH:mm:ss:ff}", stopWatch);
        }

        private void Display_TextChanged(object sender, EventArgs e)
        {
            if (Keyboard.Enabled && Display.Text.Length == 25 && TubePayphone.check_removal_tube && ReceiverCard.check_on_insert_card)
            {
                Keyboard.Enabled = false;
                TubePayphone.Play_sound_before_talk();
                outputFilename = phone + ".wav";
                if (TubePayphone.start_talk)
                {
                    Display.Text = "Введенный номер: \n" + phone + "  Идет разговор!";
                    Start_timer();
                    Start_timer_card();
                    Recording_Talk();
                    CardReader.Enabled = true;
                }
                else
                {
                    Display.Text = "Номер занят!";
                    Display.AppendText(" Выньте карту!");
                    CardReader.Enabled = true;

                }
            }
        }

        // WaveIn - поток для записи
        WaveIn waveIn;
        //Класс для записи в файл
        WaveFileWriter writer;
        //Имя файла для записи
        string outputFilename = "имя_файла.wav";

        //Получение данных из входного буфера 
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                //Записываем данные из буфера в файл
                writer.WriteData(e.Buffer, 0, e.BytesRecorded);
            }
        }
        //Завершаем запись
        void StopRecording()
        {
            waveIn.StopRecording();
        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(waveIn_RecordingStopped), sender, e);
            }
            else
            {
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
            }
        }
        //Начинаем запись - обработчик нажатия кнопки
        private void Recording_Talk()
        {
            try
            {
                waveIn = new WaveIn();
                //Дефолтное устройство для записи (если оно имеется)
                //встроенный микрофон ноутбука имеет номер 0
                waveIn.DeviceNumber = 0;
                //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                waveIn.DataAvailable += waveIn_DataAvailable;
                //Прикрепляем обработчик завершения записи
                waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);
                //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                //Инициализируем объект WaveFileWriter
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                //Начало записи
                waveIn.StartRecording();
            }
            catch (Exception)
            {
                MessageBox.Show("Микрофон не найден!");
            }
        }
    }
}
