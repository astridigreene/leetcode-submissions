public class UndergroundSystem {
    public class Person {
        public bool checked_in;
        public int start_time;
        public string start_station;
    }
    public class Stats {
        public int total;
        public int count;
    }
    Dictionary<string, Stats> times = new Dictionary<string, Stats>();
    Dictionary<int, Person> people = new Dictionary<int, Person>();
    public UndergroundSystem() {
        
    }
    
    public void CheckIn(int id, string stationName, int t) {
        if (people.ContainsKey(id)) {
            if (people[id].checked_in) {
                return;
            }
            people[id].checked_in = true;
            people[id].start_time = t;
            people[id].start_station = stationName;
            return;
        }
        Person person = new Person();
        person.checked_in = true;
        person.start_time = t;
        person.start_station = stationName;
        people.Add(id, person);
    }
    
    public void CheckOut(int id, string stationName, int t) {
        string journey = people[id].start_station + "/" + stationName;
        if (times.ContainsKey(journey)) {
            times[journey].total += t - people[id].start_time;
            times[journey].count++;
        }
        else {
            Stats stats = new Stats();
            stats.total = t - people[id].start_time;
            stats.count = 1;
            times.Add(journey, stats);
        }
        people[id].checked_in = false;
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        string journey = startStation + "/" + endStation;
        return (double)times[journey].total/times[journey].count;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */