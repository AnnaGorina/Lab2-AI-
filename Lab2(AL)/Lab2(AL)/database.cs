using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_AL_
{
    public class Database
    {
        private static Database instance;

        private static List<string> ifRules;
        private static List<string> elseRules;

        private static List<string> sports;
        private static List<string> indexSport;

        private static List<string> index;

        private Database()
        {
            ifRules = new List<string>();
            elseRules = new List<string>();

            sports = new List<string>();
            indexSport = new List<string>();

            index = new List<string>();
        }

        public static Database getInstance()
        {
            if (instance == null)
                instance = new Database();
            return instance;
        }

        public static void ifListRules(out List<string> resIfRules)
        {
            getInstance();
            resIfRules = new List<string>();
            for (int i = 0; i < ifRules.Count; i++)
            {
                resIfRules.Add(ifRules[i]);
            }
        }

        public static void elseListRules(out List<string> resElseRule)
        {
            getInstance();
            resElseRule = new List<string>();
            for (int i = 0; i < elseRules.Count; i++)
            {
                resElseRule.Add(elseRules[i]);
            }
        }

        public static void isSport(out List<string> resSport)
        {
            getInstance();
            resSport = new List<string>();
            for (int i = 0; i < sports.Count; i++)
            {
                resSport.Add(sports[i]);
            }
        }

        public static void isIndexSport(out List<string> resIndexSport)
        {
            getInstance();
            resIndexSport = new List<string>();
            for (int i = 0; i < indexSport.Count; i++)
            {
                resIndexSport.Add(indexSport[i]);
            }
        }

        public static void isIndex(out List<string> resIndex)
        {
            getInstance();
            resIndex = new List<string>();
            for (int i = 0; i < index.Count; i++)
            {
                resIndex.Add(index[i]);
            }
        }

        public static void addIfRules(string ifString)
        {
            ifRules.Add(ifString);
        }

        public static void addElseRules(string elseString)
        {
            elseRules.Add(elseString);
        }

        public static void addSport(string sportString)
        {
            sports.Add(sportString);
        }

        public static void addIndexSport(string indexSportString)
        {
            indexSport.Add(indexSportString);
        }

        public static void addIndex(string indexString)
        {
            index.Add(indexString);
        }

        public static void removeIfRules(string ifString)
        {
            ifRules.Remove(ifString);
        }

        public static void removeElseRules(string elseString)
        {
            elseRules.Remove(elseString);
        }

        public static void removeSport(string sportString)
        {
            sports.Remove(sportString);
        }

        public static void removeIndexSport(string indexSportString)
        {
            indexSport.Remove(indexSportString);
        }

        public static void removeIndex(string indexString)
        {
            index.Remove(indexString);
        }
    }
}
