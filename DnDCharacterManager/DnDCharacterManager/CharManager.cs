﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace DnDCharacterManager
{
    public class CharManager
    {
        public readonly List<Spell> lSpellList;
        public CharManager()
        {
            int iSpellLevel = 0;

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ListViewSpells)).Assembly;
            Stream spellListStream = assembly.GetManifestResourceStream("DnDCharacterManager.Resources.spelllist.txt");
            Stream spellDescStream = assembly.GetManifestResourceStream("DnDCharacterManager.Resources.spelldescs.txt");

            List<string> fileSpellList = new List<string>();
            using (var reader = new StreamReader(spellListStream))
            {
                while (reader.Peek() >= 0)
                    fileSpellList.Add(reader.ReadLine());
            }

            List<string> fileSpellDescs = new List<string>();
            using (var reader = new StreamReader(spellDescStream))
            {
                while (reader.Peek() >= 0)
                    fileSpellDescs.Add(reader.ReadLine());
            }

            foreach (string line in fileSpellDescs)
            {
                if (line.StartsWith("#"))
                {
                    bool isCaps = true;
                    foreach (char c in line.Substring(1))
                    {
                        if (Char.IsLower(c))
                        {
                            isCaps = false;
                            break;
                        }
                    }
                    if (isCaps)
                    {
                        System.Globalization.TextInfo txtInf = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                        fileSpellDescs[fileSpellDescs.IndexOf(line)] = txtInf.ToTitleCase(line);
                    }
                }
            }

            lSpellList = new List<Spell>();
            List<string> lClasses = new List<string>();
            string sName;
            string sCastingTime;
            string sRange;
            string sSpellType;
            List<string> lComponents;
            string sDuration;
            string sDesc = "";
            string sShortDesc = "";

            foreach (string spell in fileSpellList)
            {
                if (spell.StartsWith("-"))
                {
                    if (!spell.EndsWith("0"))
                        iSpellLevel++;
                    continue;
                }
                else
                {
                    sName = spell.Substring(0, spell.IndexOf("(") - 1);
                    lClasses = new List<string>();
                    string sClasses = spell.Substring(spell.IndexOf("(") + 1);
                    while (sClasses.IndexOf(")") > 0)
                    {
                        if (sClasses.IndexOf(",") > 0)
                        {
                            lClasses.Add(sClasses.Substring(0, sClasses.IndexOf(",")));
                            sClasses = sClasses.Substring(sClasses.IndexOf(",") + 2);
                        }
                        else
                        {
                            lClasses.Add(sClasses.Substring(0, sClasses.IndexOf(")")));
                            break;
                        }
                    }

                    int iStartValue = fileSpellDescs.IndexOf("#" + sName);
                    if (iStartValue < 0)
                    {
                        lSpellList.Add(new Spell(sName, iSpellLevel, lClasses, "", "", "", new List<string>(), "", "", ""));
                        continue;
                    }

                    sCastingTime = fileSpellDescs[iStartValue + 2].Substring(fileSpellDescs[iStartValue + 2].IndexOf(":") + 2);
                    sRange = fileSpellDescs[iStartValue + 3].Substring(fileSpellDescs[iStartValue + 3].IndexOf(":") + 2);
                    sSpellType = fileSpellDescs[iStartValue + 1];
                    sDuration = fileSpellDescs[iStartValue + 5].Substring(fileSpellDescs[iStartValue + 5].IndexOf(":") + 2);
                    sShortDesc = "";

                    lComponents = new List<string>();
                    string sComponents = fileSpellDescs[iStartValue + 4].Substring(fileSpellDescs[iStartValue + 4].IndexOf(" ") + 1);
                    while (sComponents != "")
                    {
                        if (sComponents.IndexOf(",") > 0)
                        {
                            lComponents.Add(sComponents.Substring(0, sComponents.IndexOf(",")));
                            sComponents = sComponents.Substring(sComponents.IndexOf(",") + 2);
                        }
                        else
                        {
                            lComponents.Add(sComponents);
                            break;
                        }
                    }
                    if (sName.Contains("Acid"))
                        sName = sName;


                    string sDescLine = "";
                    sDesc = "";
                    while (!sDescLine.StartsWith("#") && iStartValue + 6 < fileSpellDescs.Count)
                    {
                        if (sDesc == "")
                            sDesc = sDescLine;
                        else
                            sDesc += " " + sDescLine;
                        sDescLine = fileSpellDescs[iStartValue + 6];
                        iStartValue++;
                    }

                    lSpellList.Add(new Spell(sName, iSpellLevel, lClasses, sCastingTime, sRange, sSpellType, lComponents, sDuration, sDesc, sShortDesc));
                }
            }
            lSpellList.Sort();
        }
    }
}
