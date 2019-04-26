using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using SwimApplicationLibrary;

namespace swimGUIAssignment4
{
    public partial class Home : Form
    {
        SoundforGUI sog = new SoundforGUI();
        /*fields*/
        private List<Club> clubs;
        private List<Swimmer> swimmers;
        private List<Coach> coaches;
        private List<Event> swimEvents;
        private List<SwimMeet> swimMeets;

        /*properties*/
        public List<Club> Clubs
        {
            set
            {
                clubs = value; 
            }
            get
            {
                return clubs;
            }
        }
        public List<Swimmer> Swimmers
        {
            set
            {
                swimmers = value;
            }
            get
            {
                return swimmers;
            }
        }
        public List<Coach> Coaches
        {
            set
            {
                coaches = value;
            }
            get
            {
                return coaches;
            }
        }
        public List<Event> SwimEvents
        {
            set
            {
                swimEvents = value;
            }
            get
            {
                return swimEvents;
            }
        }
        public List<SwimMeet> SwimMeets
        {
            set
            {
                swimMeets = value;
            }
            get
            {
                return swimMeets;
            }
        }

        public Home()
        {
            InitializeComponent();
        }

        /*Displaying related form when user clicks the button*/
        private void clubFormDirector_Click(object sender, EventArgs e)
        {
            sog.SoundButton();
            ClubGUI clubGUI = new ClubGUI();
            clubGUI.Clubs = this.Clubs;
            clubGUI.Swimmers = this.Swimmers;
            clubGUI.Coaches = this.Coaches;
            clubGUI.ShowDialog(this);

        }

        private void swimmerFormDirector_Click(object sender, EventArgs e)
        {
            sog.SoundButton();
            SwimmerGUI swimmerGUI = new SwimmerGUI();
            swimmerGUI.Swimmers = this.Swimmers;
            swimmerGUI.ShowDialog(this);
        }

        private void coachFormDirector_Click(object sender, EventArgs e)
        {
            sog.SoundButton();
            CoachGUI coachGUI = new CoachGUI();
            coachGUI.Coaches = this.Coaches;
            coachGUI.Swimmers = this.Swimmers;
            coachGUI.ShowDialog(this);

        }

        private void eventFormDirector_Click(object sender, EventArgs e)
        {
            sog.SoundButton();
            EventGUI eventGUI = new EventGUI();
            eventGUI.SwimEvents = this.SwimEvents;
            eventGUI.Swimmers = this.Swimmers;
            eventGUI.ShowDialog(this);

        }

        private void swimMeetFormDirector_Click(object sender, EventArgs e)
        {
            sog.SoundButton();
            SwimMeetGUI swimMeetGUI = new SwimMeetGUI();
            swimMeetGUI.SwimMeets = this.SwimMeets;
            swimMeetGUI.SwimEvents = this.SwimEvents;
            swimMeetGUI.ShowDialog(this);

        }

        /*Creating the Club*/
        private static void CreateClubs(out Club club1, out Club club2)
        {
            club1 = new Club();
            club1.PhoneNumber = 4164444444;
            club1.Name = "NYAC";
            club2 = new Club("CCAC", new Address("35 River St", "Toronto", "ON", "M2M 5M5"), 4165555555);
        }

        /*creating the Swimmers*/
        private static void CreateSwimmers(out Swimmer swimmer1, out Swimmer swimmer2, out Swimmer swimmer3)
        {
            //first Swimmer
            swimmer1 = new Swimmer("Bob Smith", new DateTime(1970, 1, 1),
                                                    new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            //Second Swimmer
            swimmer2 = new Swimmer();
            swimmer2.Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3");
            swimmer2.Name = "John Lee";
            swimmer2.PhoneNumber = 4162222222;
            swimmer2.DateOfBirth = new DateTime(1950, 12, 1);

            //Third Swimmer
            swimmer3 = new Swimmer("Ann Smith", new DateTime(1975, 1, 1),
                                                    new Address("5 Queen St", "Toronto", "ON", "M2M 4M4"), 4163333333);
        }

        /*Creating Coach*/
        private static void CreateCoaches(out Coach coach1, out Coach coach2)
        {

            //Coach 1
            coach1 = new Coach("John Wisemiler", new DateTime(1950, 1, 1),
                                                    new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);

            //Coach 2
            coach2 = new Coach("Micael Phelps", new DateTime(1975, 6, 30),
                                                    new Address("5 Queen St", "Boston", "ON", "234567"), 3123123333);
            coach2.Credentials = "NNCA Level 1";
        }

        /*Creating Events*/
        private static void CreateEvents(out Event _50free1, out Event _100fly, out Event _200breast, out Event _400free, out Event _1500free, out Event _1500free2)
        {
         
            //First Event
            _50free1 = new Event();
            _50free1.Distance = EventDistance._50;
            _50free1.Stroke = Stroke.Freestyle;
            //Second Event
            _100fly = new Event(EventDistance._100, Stroke.Butterfly);
            //Third Event
            _200breast = new Event(EventDistance._200, Stroke.Breaststroke);
            //Fourth Event
            _400free = new Event(EventDistance._400, Stroke.Freestyle);
            //Fifth Event
            _1500free = new Event(EventDistance._1500, Stroke.Freestyle);
            //Sixth Event
            _1500free2 = new Event(EventDistance._1500, Stroke.Freestyle);
        }

        /*Creating Swim Meet*/
        private static void CreateSwimMeets(out SwimMeet meet1, out SwimMeet meet2)
        {
            // First Swim Meet
            meet1 = new SwimMeet();
            meet1.Name = "Winnter Splash";
            meet1.StartDate = new DateTime(2017, 1, 10);
            meet1.EndDate = new DateTime(2017, 1, 12);

            // Second Swim Meet
            meet2 = new SwimMeet("Spring Splash", new DateTime(2017, 5, 21), new DateTime(2017, 5, 21), PoolType.SCM, 2);
        }

        /*Adding Swimmer to Event*/
        private static void AddSwimmersToEvents(Registrant swimmer1, Registrant swimmer2, Registrant swimmer3, SwimMeet meet1, SwimMeet meet2, Event _50free1, Event _100fly, Event _200breast, Event _400free, Event _1500free, Event _1500free2)
        {

            //Add swimmers to _50free1 event
            _50free1.AddSwimmer(swimmer1);
            _50free1.AddSwimmer(swimmer2);
            _50free1.AddSwimmer(swimmer3);

            //Add swimmers to _100fly event
            _100fly.AddSwimmer(swimmer1);
            _100fly.AddSwimmer(swimmer2);

            //Add swimmers to _200breast event
            _200breast.AddSwimmer(swimmer1);
            _200breast.AddSwimmer(swimmer2);
            _200breast.AddSwimmer(swimmer3);

            //Add swimmers to _400free event
            _400free.AddSwimmer(swimmer2);

            //Add swimmers to _1500free event
            _1500free.AddSwimmer(swimmer1);
            _1500free.AddSwimmer(swimmer2);
            _1500free.AddSwimmer(swimmer3);

            //Add swimmers to _1500free2 event
            _1500free2.AddSwimmer(swimmer1);
            _1500free2.AddSwimmer(swimmer3);
        }

        /*Adding Event to Swim Meet*/
        private static void AddEventsToSwimMeets(SwimMeet meet1, SwimMeet meet2, Event _50free1, Event _100fly, Event _200breast, Event _400free, Event _1500free, Event _1500free2)
        {

            // Adding Events to First Meet 
            meet1.AddEvent(_50free1);
            meet1.AddEvent(_100fly);
            meet1.AddEvent(_200breast);
            meet1.AddEvent(_1500free2);

            // Addign Events to Second Meet
            meet2.AddEvent(_400free);
            meet2.AddEvent(_1500free);

        }

        /*Load all the Object as the Application Starts*/
        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;

            //Clubs
            Clubs = new List<Club>();
            Club club1;
            Club club2;
            CreateClubs(out club1, out club2);
            Clubs.AddRange(new[] { club1, club2 });

            //Swimmers 
            Swimmers = new List<Swimmer>();
            Swimmer swimmer1;
            Swimmer swimmer2;
            Swimmer swimmer3;
            CreateSwimmers(out swimmer1, out swimmer2, out swimmer3);
            Swimmers.AddRange(new[] { swimmer1, swimmer2, swimmer3 });

            //Coaches
            Coaches = new List<Coach>();
            Coach coach1;
            Coach coach2;
            CreateCoaches(out coach1, out coach2);
            Coaches.AddRange(new[] { coach1, coach2});

            //SwimMeet
            SwimMeets = new List<SwimMeet>();
            SwimMeet meet1;
            SwimMeet meet2;
            CreateSwimMeets(out meet1, out meet2);
            SwimMeets.AddRange(new[] { meet1, meet2 });

            //Events
            SwimEvents = new List<Event>();
            Event _50free1;
            Event _100fly;
            Event _200breast;
            Event _400free;
            Event _1500free;
            Event _1500free2;
            CreateEvents(out _50free1, out _100fly, out _200breast,
                out _400free, out _1500free, out _1500free2);
            SwimEvents.AddRange(new[] { _50free1, _100fly, _200breast,
                _400free, _1500free, _1500free2 });
            
            //Adding Swimmers to the Event
            AddSwimmersToEvents(swimmer1, swimmer2, swimmer3, meet1, meet2,
                                _50free1, _100fly, _200breast, _400free, _1500free, _1500free2);

            // Adding Events to the Swim Meet
            AddEventsToSwimMeets(meet1, meet2, _50free1, _100fly, _200breast,
                _400free, _1500free, _1500free2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
            label2.ForeColor = Color.FromArgb(A, R, G, B);
        }
    }
}
