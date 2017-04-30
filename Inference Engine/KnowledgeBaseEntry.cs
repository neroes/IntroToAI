﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inference_Engine
{

    public struct KnowledgeBaseEntry
    {
        enum Clause: byte{ True, False, Both, Null };
        Clause[] clauses;

        public KnowledgeBaseEntry(string input)
        {
            clauses = new Clause[4];
            string[] splitline = input.Split(',');
            foreach (string line in splitline)
            {
                if (line[0] == '~')
                {
                    switch (line[1])
                    {
                        case 'a':
                            if (clauses[0] == Clause.True) { clauses[0] = Clause.Both; }
                            else { clauses[0] = Clause.False; }
                            break;
                        case 'b':
                            if (clauses[1] == Clause.True) { clauses[1] = Clause.Both; }
                            else { clauses[1] = Clause.False; }
                            break;
                        case 'c':
                            if (clauses[2] == Clause.True) { clauses[2] = Clause.Both; }
                            else { clauses[2] = Clause.False; }
                            break;
                        case 'd':
                            if (clauses[3] == Clause.True) { clauses[3] = Clause.Both; }
                            else { clauses[3] = Clause.False; }
                            break;
                    }
                }
                else
                {
                    switch (line[0])
                    {
                        case 'a':
                            if (clauses[0] == Clause.False) { clauses[0] = Clause.Both; }
                            else { clauses[0] = Clause.True; }
                            break;
                        case 'b':
                            if (clauses[1] == Clause.False) { clauses[1] = Clause.Both; }
                            else { clauses[1] = Clause.True; }
                            break;
                        case 'c':
                            if (clauses[2] == Clause.False) { clauses[2] = Clause.Both; }
                            else { clauses[2] = Clause.True; }
                            break;
                        case 'd':
                            if (clauses[3] == Clause.False) { clauses[3] = Clause.Both; }
                            else { clauses[3] = Clause.True; }
                            break;
                    }
                }

            }
        }
        public KnowledgeBaseEntry(KnowledgeBaseEntry know1, KnowledgeBaseEntry know2)
        {
            clauses = new Clause[4];
            for (int i = 0; i < 4; i++)
            {
                if (know1[i] == Clause.False && know2[i] == Clause.True)
                {
                    clauses[i] = Clause.Null;
                }
                else if (know1[i] == Clause.True && know2[i] == Clause.False)
                {
                    clauses[i] = Clause.Null;
                }
                else if (know2[i] == Clause.Both)
                {
                    clauses[i] = Clause.Null;
                }
                else if (know2[i] == Clause.False)
                {
                    clauses[i] = Clause.False;
                }
                else if (know2[i] == Clause.True)
                {
                    clauses[i] = Clause.True;
                }
            }

            //this.h = know1.h++;

        }
        Clause this[int i] { get { return clauses[i]; } }
        public int h()
        {
            int h = 0;
            foreach (Clause claus in clauses)
            {
                if (claus != Clause.Null)
                {
                    h++;
                }
            }
            return h;
        }
        /*public int f()
        {
            
            return g+h();
        }*/
        public bool isgoal()
        {
            foreach (Clause claus in clauses)
            {
                if (claus != Clause.Null)
                {
                    return false;
                }
            }
            return true;
        }
        public string toString()
        {
            char[] letters = new char[4];
            letters[0] = 'a'; letters[1] = 'b'; letters[2] = 'c'; letters[3] = 'd';
            string returnstring = "";
            int i = 0;
            while (clauses[i] == Clause.Both)
            {
                i++;
            }
            switch (clauses[i])
            {
                case Clause.True:
                    returnstring += letters[i];
                    break;
                case Clause.False:
                    returnstring += "~" + letters[i];
                    break;
                case Clause.Both:
                    returnstring += "(" + letters[i] + " || ~" + letters[i] + ")";
                    break;
                case Clause.Null:
                    break;
            }
            i++;
            while (i < 4)
            {
                switch (clauses[i])
                {
                    case Clause.True:
                        returnstring += " || " + letters[i];
                        break;
                    case Clause.False:
                        returnstring += " || ~" + letters[i];
                        break;
                    case Clause.Both:
                        returnstring += " || (" + letters[i] + " || ~" + letters[i] + ")";
                        break;
                    case Clause.Null:
                        break;
                }
                i++;
            }
            return returnstring;
        }
    }
}