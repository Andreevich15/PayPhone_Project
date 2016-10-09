using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Timers;
namespace Project_Course_Work
{
    class Tube_Payphone
    {
        public bool check_removal_tube { get; set; }
        public bool signal_from_ATS { get; set; }

        public bool start_talk { get; set; }

        public Tube_Payphone()
        {
            check_removal_tube = false;
            signal_from_ATS = false;
            start_talk = false;
        }

        Random rnd = new Random();
        public string generate_signal_from_ATS()
        {
            string signal = "ton";
            int choice = rnd.Next(0, 4);
            if (choice == 0) signal = "busy";
            return signal;
        }

        SoundPlayer sp;

        public void Play_sound_from_ATS(string for_sound)
        {
            if (for_sound == "ton")
            {
                sp = new SoundPlayer(Environment.CurrentDirectory + "\\Sounds\\ready.wav");
                signal_from_ATS = true;
            }
            else sp = new SoundPlayer(Environment.CurrentDirectory + "\\Sounds\\busy.wav");
            sp.Play();
        }

        public void Play_sound_before_talk()
        {
            sp = new SoundPlayer(Environment.CurrentDirectory + "\\Sounds\\ton.wav");
            sp.Play();
            if (!Convert.ToBoolean(rnd.Next(0, 10)))
            {
                sp = new SoundPlayer(Environment.CurrentDirectory + "\\Sounds\\not_respond.wav");
                sp.Play();
            }
            else
            {
                DateTime t = DateTime.Now;
                while ((DateTime.Now - t).TotalSeconds < 5){}
                sp.Stop();
                start_talk = true;
            }
        }
    }

    class Display_Message
    {
        public string Start_Message() { return "Вставьте карту!"; }

        public string Limit_card_used() { return "Лимит карты исчерпан!"; }
        public string For_crashed_card() { return "Карта непригодна для использования!"; }

        public string Ready_and_card_limit(double card_lim)
        {
            string ready = "Карта готова! Лимит карты: " + card_lim + " минут";
            return ready;
        }

        public string Talk_Complete() { return "Разговор завершен!"; }
    }

    class Receiver_Card
    {
        public double card_limit { get; set; }
        public bool check_on_insert_card { get; set; }

        public Receiver_Card()
        {
            card_limit = 0;
            check_on_insert_card = false;
        }
        public bool check_suitability_card()
        {
            Random crasher = new Random();
            if (Convert.ToBoolean(crasher.Next(0, 5)))
                return true;
            else return false;
        }
    }

    class ListHandlerEventArgs : System.EventArgs
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string Talk_time { get; set; }
        public ListHandlerEventArgs()
        {
            StartTime = DateTime.Now;
            Talk_time = "";
        }
        public ListHandlerEventArgs(DateTime f_starttime, DateTime f_stoptime, string f_talktime)
        {
            StartTime = f_starttime;
            StopTime = f_stoptime;
            Talk_time = f_talktime;
        }
    }

    class JournalEntry
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string Talk_time { get; set; }
        public JournalEntry()
        {
            StartTime = DateTime.Now;
            Talk_time = "";
        }
        public JournalEntry(DateTime f_starttime, DateTime f_stoptime, string f_talktime)
        {
            StartTime = f_starttime;
            StopTime = f_stoptime;
            Talk_time = f_talktime;
        }
        string Information()
        {
            string info = "Начало разговора->" + StartTime + "; Конец разговора->" + StopTime + "; Время разговора->" + Talk_time + "\n";
            return info;
        }
        public override string ToString()
        {
            return Information();
        }
    }
    class TeamsJournal
    {
        List<JournalEntry> events = new List<JournalEntry>();
        public void NewEvents(object sender, ListHandlerEventArgs f_info)
        {
            JournalEntry teamEvent = new JournalEntry(f_info.StartTime, f_info.StopTime, f_info.Talk_time);
            events.Add(teamEvent);
        }
        public string Information()
        {
            string info = "";
            foreach (var item in events)
            {
                info += item;
                info += "\n";
            }
            return info;
        }
        public override string ToString() { return Information(); }
    }
}