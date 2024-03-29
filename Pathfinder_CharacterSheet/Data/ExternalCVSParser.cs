using Microsoft.VisualBasic.FileIO;
using Pathfinder_CharacterSheet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pathfinder_CharacterSheet.Data
{
    public static class ExternalCSVParser<T>
    {
        public static IEnumerable<T> ParseSpellsFromCsv(Dictionary<string, string> fieldsMapping, string pathToCsv)
        {
            using (TextFieldParser parser = new TextFieldParser(@pathToCsv))
            {

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                List<string> fieldsFromExternalSource = new List<string>(); 
                List<string> mappedKeys = fieldsMapping.Keys.ToList(); 
                List<T> resultObjects = new List<T>(); 


                while (!parser.EndOfData)
                {
                    
                    T currentModelObject = (T)Activator.CreateInstance(typeof(T), new object[] { });

                   
                    var modelType = currentModelObject.GetType();
                    
                    string[] rowEntries = parser.ReadFields();
                    foreach (var (column, index) in rowEntries.Select((value, i) => (value, i)))
                    {
                      
                        if (parser.LineNumber == 2)
                        {
                            fieldsFromExternalSource = rowEntries.ToList();
                        }
                        else if (parser.LineNumber > 2)
                        {
                          
                            if (mappedKeys.Contains(fieldsFromExternalSource[index]))
                            {
                               
                                var modelProperty = modelType.GetProperty(fieldsMapping[fieldsFromExternalSource[index]]);
                                if (modelProperty != null)
                                {
                                
                                    if (modelProperty.PropertyType == typeof(string))
                                    {
                                        modelProperty.SetValue(currentModelObject, column);
                                    }
                                    else if (modelProperty.PropertyType == typeof(int))
                                    {
                                       
                                    }
                                    else if (modelProperty.PropertyType == typeof(bool))
                                    {
                                       
                                        bool propertyValue = false;
                                        if (column == "no")
                                        {
                                            propertyValue = false;
                                        }
                                        else
                                        {
                                            propertyValue = true;
                                        }
                                    }
                                    else
                                    {
                                        
                                        continue;
                                    }
                                }
                            }

                        }
                    }

                   
                    if ((currentModelObject as IBaseItem).Name != null)
                    {
                        resultObjects.Add(currentModelObject);
                    }
                }

                return resultObjects;
            }
        }
    }
}