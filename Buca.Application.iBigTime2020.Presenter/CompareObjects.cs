﻿/***********************************************************************
 * <copyright file="CompareObjects.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, October 22, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;

namespace Buca.Application.iBigTime2020.Presenter
{
    /// <summary>
    /// Class that allows comparison of two objects of the same type to each other.  Supports classes, lists, arrays, dictionaries, child comparison and more.
    /// </summary>
    public class CompareObjects
    {
        #region Class Variables
        /// <summary>
        /// The _parents
        /// </summary>
        private readonly List<object> _parents = new List<object>();
        #endregion

        #region Properties

        /// <summary>
        /// Ignore classes, properties, or fields by name during the comparison.
        /// Case sensitive.
        /// </summary>
        /// <value>
        /// The elements to ignore.
        /// </value>
        public List<string> ElementsToIgnore { get; set; }

        /// <summary>
        /// If true, private properties and fields will be compared. The default is false.
        /// </summary>
        /// <value>
        /// <c>true</c> if [compare private properties]; otherwise, <c>false</c>.
        /// </value>
        public bool ComparePrivateProperties { get; set; }

        /// <summary>
        /// If true, private fields will be compared. The default is false.
        /// </summary>
        /// <value>
        /// <c>true</c> if [compare private fields]; otherwise, <c>false</c>.
        /// </value>
        public bool ComparePrivateFields { get; set; }

        /// <summary>
        /// If true, static properties will be compared.  The default is true.
        /// </summary>
        /// <value>
        /// <c>true</c> if [compare static properties]; otherwise, <c>false</c>.
        /// </value>
        public bool CompareStaticProperties { get; set; }

        /// <summary>
        /// If true, static fields will be compared.  The default is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compare static fields]; otherwise, <c>false</c>.
        /// </value>
        public bool CompareStaticFields { get; set; }

        /// <summary>
        /// If true, child objects will be compared. The default is true.
        /// If false, and a list or array is compared list items will be compared but not their children.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compare children]; otherwise, <c>false</c>.
        /// </value>
        public bool CompareChildren { get; set; }

        /// <summary>
        /// If true, compare read only properties (only the getter is implemented).
        /// The default is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compare read only]; otherwise, <c>false</c>.
        /// </value>
        public bool CompareReadOnly { get; set; }

        /// <summary>
        /// If true, compare fields of a class (see also CompareProperties).
        /// The default is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compare fields]; otherwise, <c>false</c>.
        /// </value>
        public bool CompareFields { get; set; }

        /// <summary>
        /// If true, compare properties of a class (see also CompareFields).
        /// The default is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compare properties]; otherwise, <c>false</c>.
        /// </value>
        public bool CompareProperties { get; set; }

        /// <summary>
        /// The maximum number of differences to detect
        /// </summary>
        /// <value>
        /// The maximum differences.
        /// </value>
        /// <remarks>
        /// Default is 1 for performance reasons.
        /// </remarks>
        public int MaxDifferences { get; set; }

        /// <summary>
        /// The differences found during the compare
        /// </summary>
        /// <value>
        /// The differences.
        /// </value>
        public List<String> Differences { get; set; }

        /// <summary>
        /// The differences found in a string suitable for a textbox
        /// </summary>
        /// <value>
        /// The differences string.
        /// </value>
        public string DifferencesString
        {
            get
            {
                var sb = new StringBuilder(4096);

                sb.Append("\r\nBegin Differences:\r\n");

                foreach (string item in Differences)
                {
                    sb.AppendFormat("{0}\r\n", item);
                }

                sb.AppendFormat("End Differences (Maximum of {0} differences shown).", MaxDifferences);

                return sb.ToString();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Set up defaults for the comparison
        /// </summary>
        public CompareObjects()
        {
            Differences = new List<string>();
            ElementsToIgnore = new List<string>();
            CompareStaticFields = true;
            CompareStaticProperties = true;
            ComparePrivateProperties = false;
            ComparePrivateFields = false;
            CompareChildren = true;
            CompareReadOnly = true;
            CompareFields = true;
            CompareProperties = true;
            MaxDifferences = 1;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Compare two objects of the same type to each other.
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <returns>
        /// True if they are equal
        /// </returns>
        /// <remarks>
        /// Check the Differences or DifferencesString Properties for the differences.
        /// Default MaxDifferences is 1 for performance
        /// </remarks>
        public bool Compare(object object1, object object2)
        {
            string defaultBreadCrumb = string.Empty;

            Differences.Clear();
            Compare(object1, object2, defaultBreadCrumb);

            return Differences.Count == 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Compare two objects
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">Where we are in the object hiearchy</param>
        /// <exception cref="NotImplementedException">Cannot compare object of type  + t1.Name</exception>
        private void Compare(object object1, object object2, string breadCrumb)
        {
            //If both null return true
            if (object1 == null && object2 == null)
                return;

            //Check if one of them is null
            if (object1 == null)
            {
                Differences.Add(string.Format("object1{0} == null && object2{0} != null ((null),{1})", breadCrumb, cStr(object2)));
                return;
            }

            if (object2 == null)
            {
                Differences.Add(string.Format("object1{0} != null && object2{0} == null ({1},(null))", breadCrumb, cStr(object1)));
                return;
            }

            Type t1 = object1.GetType();
            Type t2 = object2.GetType();

            //Objects must be the same type
            if (t1 != t2)
            {
                Differences.Add(string.Format("Different Types:  object1{0}.GetType() != object2{0}.GetType()", breadCrumb));
                return;
            }

            if (IsDataset(t1))
            {
                CompareDataset(object1, object2, breadCrumb);
            }
            else if (IsDataTable(t1))
            {
                CompareDataTable(object1, object2, breadCrumb);
            }
            else if (IsDataRow(t1))
            {
                CompareDataRow(object1, object2, breadCrumb);
            }
            else if (IsIList(t1)) //This will do arrays, multi-dimensional arrays and generic lists
            {
                CompareIList(object1, object2, breadCrumb);
            }
            else if (IsIDictionary(t1))
            {
                CompareIDictionary(object1, object2, breadCrumb);
            }
            else if (IsEnum(t1))
            {
                CompareEnum(object1, object2, breadCrumb);
            }
            else if (IsSimpleType(t1))
            {
                CompareSimpleType(object1, object2, breadCrumb);
            }
            else if (IsClass(t1))
            {
                CompareClass(object1, object2, breadCrumb);
            }
            else if (IsTimespan(t1))
            {
                CompareTimespan(object1, object2, breadCrumb);
            }
            else if (IsStruct(t1))
            {
                CompareStruct(object1, object2, breadCrumb);
            }
            else
            {
                throw new NotImplementedException("Cannot compare object of type " + t1.Name);
            }

        }

        /// <summary>
        /// Compares the data row.
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <exception cref="ArgumentNullException">
        /// object1
        /// or
        /// object2
        /// </exception>
        /// <exception cref="ArgumentNullException">object1
        /// or
        /// object2</exception>
        private void CompareDataRow(object object1, object object2, string breadCrumb)
        {
            var dataRow1 = object1 as DataRow;
            var dataRow2 = object2 as DataRow;

            if (dataRow1 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object1");

            if (dataRow2 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object2");

            for (int i = 0; i < dataRow1.Table.Columns.Count; i++)
            {
                //If we should ignore it, skip it
                if (ElementsToIgnore.Contains(dataRow1.Table.Columns[i].ColumnName))
                    continue;

                //If we should ignore read only, skip it
                if (!CompareReadOnly && dataRow1.Table.Columns[i].ReadOnly)
                    continue;

                //Both are null
                if (dataRow1.IsNull(i) && dataRow2.IsNull(i))
                    continue;

                string currentBreadCrumb = AddBreadCrumb(breadCrumb, string.Empty, string.Empty, dataRow1.Table.Columns[i].ColumnName);

                //Check if one of them is null
                if (dataRow1.IsNull(i))
                {
                    Differences.Add(string.Format("object1{0} == null && object2{0} != null ((null),{1})", currentBreadCrumb, cStr(object2)));
                    return;
                }

                if (dataRow2.IsNull(i))
                {
                    Differences.Add(string.Format("object1{0} != null && object2{0} == null ({1},(null))", currentBreadCrumb, cStr(object1)));
                    return;
                }

                Compare(dataRow1[i], dataRow2[i], currentBreadCrumb);

                if (Differences.Count >= MaxDifferences)
                    return;
            }
        }

        /// <summary>
        /// Compares the data table.
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <exception cref="ArgumentNullException">
        /// object1
        /// or
        /// object2
        /// </exception>
        /// <exception cref="ArgumentNullException">object1
        /// or
        /// object2</exception>
        private void CompareDataTable(object object1, object object2, string breadCrumb)
        {
            var dataTable1 = object1 as DataTable;
            var dataTable2 = object2 as DataTable;

            if (dataTable1 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object1");

            if (dataTable2 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object2");

            //If we should ignore it, skip it
            if (ElementsToIgnore.Contains(dataTable1.TableName))
                return;

            //There must be the same amount of rows in the datatable
            if (dataTable1.Rows.Count != dataTable2.Rows.Count)
            {
                Differences.Add(string.Format("object1{0}.Rows.Count != object2{0}.Rows.Count ({1},{2})", breadCrumb,
                                              dataTable1.Rows.Count, dataTable2.Rows.Count));

                if (Differences.Count >= MaxDifferences)
                    return;
            }

            //There must be the same amount of columns in the datatable
            if (dataTable1.Columns.Count != dataTable2.Columns.Count)
            {
                Differences.Add(string.Format("object1{0}.Columns.Count != object2{0}.Columns.Count ({1},{2})", breadCrumb,
                                              dataTable1.Columns.Count, dataTable2.Columns.Count));

                if (Differences.Count >= MaxDifferences)
                    return;
            }

            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                string currentBreadCrumb = AddBreadCrumb(breadCrumb, "Rows", string.Empty, i);

                CompareDataRow(dataTable1.Rows[i], dataTable2.Rows[i], currentBreadCrumb);

                if (Differences.Count >= MaxDifferences)
                    return;
            }
        }

        /// <summary>
        /// Compares the dataset.
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <exception cref="ArgumentNullException">
        /// object1
        /// or
        /// object2
        /// </exception>
        /// <exception cref="ArgumentNullException">object1
        /// or
        /// object2</exception>
        private void CompareDataset(object object1, object object2, string breadCrumb)
        {
            var dataSet1 = object1 as DataSet;
            var dataSet2 = object2 as DataSet;

            if (dataSet1 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object1");

            if (dataSet2 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object2");


            //There must be the same amount of tables in the dataset
            if (dataSet1.Tables.Count != dataSet2.Tables.Count)
            {
                Differences.Add(string.Format("object1{0}.Tables.Count != object2{0}.Tables.Count ({1},{2})", breadCrumb,
                                              dataSet1.Tables.Count, dataSet2.Tables.Count));

                if (Differences.Count >= MaxDifferences)
                    return;
            }

            for (int i = 0; i < dataSet1.Tables.Count; i++)
            {
                string currentBreadCrumb = AddBreadCrumb(breadCrumb, "Tables", string.Empty, dataSet1.Tables[i].TableName);

                CompareDataTable(dataSet1.Tables[i], dataSet2.Tables[i], currentBreadCrumb);

                if (Differences.Count >= MaxDifferences)
                    return;
            }
        }

        /// <summary>
        /// Determines whether the specified t is timespan.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsTimespan(Type t)
        {
            return t == typeof(TimeSpan);
        }

        /// <summary>
        /// Determines whether the specified t is enum.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsEnum(Type t)
        {
            return t.IsEnum;
        }

        /// <summary>
        /// Determines whether the specified t is structure.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsStruct(Type t)
        {
            return t.IsValueType && !IsSimpleType(t);
        }

        /// <summary>
        /// Determines whether [is simple type] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsSimpleType(Type t)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                t = Nullable.GetUnderlyingType(t);
            }

            return t.IsPrimitive
                || t == typeof(DateTime)
                || t == typeof(decimal)
                || t == typeof(string)
                || t == typeof(Guid);

        }

        /// <summary>
        /// Valids the type of the structure sub.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool ValidStructSubType(Type t)
        {
            return IsSimpleType(t)
                || IsEnum(t)
                || IsArray(t)
                || IsClass(t)
                || IsIDictionary(t)
                || IsTimespan(t)
                || IsIList(t);
        }

        /// <summary>
        /// Determines whether the specified t is array.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsArray(Type t)
        {
            return t.IsArray;
        }

        /// <summary>
        /// Determines whether the specified t is class.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsClass(Type t)
        {
            return t.IsClass;
        }

        /// <summary>
        /// Determines whether [is i dictionary] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsIDictionary(Type t)
        {
            return t.GetInterface("System.Collections.IDictionary", true) != null;
        }

        /// <summary>
        /// Determines whether the specified t is dataset.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsDataset(Type t)
        {
            return t == typeof(DataSet);
        }

        /// <summary>
        /// Determines whether [is data row] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsDataRow(Type t)
        {
            return t == typeof(DataRow);
        }

        /// <summary>
        /// Determines whether [is data table] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsDataTable(Type t)
        {
            return t == typeof(DataTable);
        }

        /// <summary>
        /// Determines whether [is i list] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsIList(Type t)
        {
            return t.GetInterface("System.Collections.IList", true) != null;
        }

        /// <summary>
        /// Determines whether [is child type] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private bool IsChildType(Type t)
        {
            return !IsSimpleType(t)
                && (IsClass(t)
                    || IsArray(t)
                    || IsIDictionary(t)
                    || IsIList(t)
                    || IsStruct(t));
        }

        /// <summary>
        /// Compare a timespan struct
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void CompareTimespan(object object1, object object2, string breadCrumb)
        {
            if (((TimeSpan)object1).Ticks != ((TimeSpan)object2).Ticks)
            {
                Differences.Add(string.Format("object1{0}.Ticks != object2{0}.Ticks", breadCrumb));
            }
        }

        /// <summary>
        /// Compare an enumeration
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void CompareEnum(object object1, object object2, string breadCrumb)
        {
            if (object1.ToString() != object2.ToString())
            {
                string currentBreadCrumb = AddBreadCrumb(breadCrumb, object1.GetType().Name, string.Empty, -1);
                Differences.Add(string.Format("object1{0} != object2{0} ({1},{2})", currentBreadCrumb, object1, object2));
            }
        }

        /// <summary>
        /// Compare a simple type
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <exception cref="ArgumentNullException">
        /// object2
        /// or
        /// object1
        /// </exception>
        private void CompareSimpleType(object object1, object object2, string breadCrumb)
        {
            if (object2 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object2");

            var valOne = object1 as IComparable;

            if (valOne == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object1");

            if (valOne.CompareTo(object2) != 0)
            {
                Differences.Add(string.Format("object1{0} != object2{0} ({1},{2})", breadCrumb, object1, object2));
            }
        }



        /// <summary>
        /// Compare a struct
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void CompareStruct(object object1, object object2, string breadCrumb)
        {
            try
            {
                _parents.Add(object1);
                _parents.Add(object2);

                Type t1 = object1.GetType();

                //Compare the fields
                FieldInfo[] currentFields = t1.GetFields();

                foreach (FieldInfo item in currentFields)
                {
                    //Only compare simple types within structs (Recursion Problems)
                    if (!ValidStructSubType(item.FieldType))
                    {
                        continue;
                    }

                    string currentCrumb = AddBreadCrumb(breadCrumb, item.Name, string.Empty, -1);

                    Compare(item.GetValue(object1), item.GetValue(object2), currentCrumb);

                    if (Differences.Count >= MaxDifferences)
                        return;
                }

                PerformCompareProperties(t1, object1, object2, breadCrumb);
            }
            finally
            {
                _parents.Remove(object1);
                _parents.Remove(object2);
            }
        }

        /// <summary>
        /// Compare the properties, fields of a class
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void CompareClass(object object1, object object2, string breadCrumb)
        {
            try
            {
                _parents.Add(object1);
                _parents.Add(object2);
                Type t1 = object1.GetType();

                //We ignore the class name
                if (ElementsToIgnore.Contains(t1.Name))
                    return;

                //Compare the properties
                if (CompareProperties)
                    PerformCompareProperties(t1, object1, object2, breadCrumb);

                //Compare the fields
                if (CompareFields)
                    PerformCompareFields(t1, object1, object2, breadCrumb);
            }
            finally
            {
                _parents.Remove(object1);
                _parents.Remove(object2);
            }
        }

        /// <summary>
        /// Compare the fields of a class
        /// </summary>
        /// <param name="t1">The t1.</param>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void PerformCompareFields(Type t1,
            object object1,
            object object2,
            string breadCrumb)
        {
            FieldInfo[] currentFields;

            if (ComparePrivateFields && !CompareStaticFields)
                currentFields = t1.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            else if (ComparePrivateFields)
                currentFields = t1.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            else if (!CompareStaticFields)
                currentFields = t1.GetFields(BindingFlags.Public | BindingFlags.Instance);
            else
                currentFields = t1.GetFields(); //Default is public instance and static

            foreach (FieldInfo item in currentFields)
            {
                //Skip if this is a shallow compare
                if (!CompareChildren && IsChildType(item.FieldType))
                    continue;

                //If we should ignore it, skip it
                if (ElementsToIgnore.Contains(item.Name))
                    continue;

                object objectValue1 = item.GetValue(object1);
                object objectValue2 = item.GetValue(object2);

                bool object1IsParent = objectValue1 != null && (objectValue1 == object1 || _parents.Contains(objectValue1));
                bool object2IsParent = objectValue2 != null && (objectValue2 == object2 || _parents.Contains(objectValue2));

                //Skip fields that point to the parent
                if (IsClass(item.FieldType)
                    && (object1IsParent || object2IsParent))
                {
                    continue;
                }

                string currentCrumb = AddBreadCrumb(breadCrumb, item.Name, string.Empty, -1);

                Compare(objectValue1, objectValue2, currentCrumb);

                if (Differences.Count >= MaxDifferences)
                    return;
            }
        }


        /// <summary>
        /// Compare the properties of a class
        /// </summary>
        /// <param name="t1">The t1.</param>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void PerformCompareProperties(Type t1,
            object object1,
            object object2,
            string breadCrumb)
        {
            PropertyInfo[] currentProperties;

            if (ComparePrivateProperties && !CompareStaticProperties)
                currentProperties = t1.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            else if (ComparePrivateProperties)
                currentProperties = t1.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            else if (!CompareStaticProperties)
                currentProperties = t1.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            else
                currentProperties = t1.GetProperties(); //Default is public instance and static

            foreach (PropertyInfo info in currentProperties)
            {
                //If we can't read it, skip it
                if (info.CanRead == false)
                    continue;

                //Skip if this is a shallow compare
                if (!CompareChildren && IsChildType(info.PropertyType))
                    continue;

                //If we should ignore it, skip it
                if (ElementsToIgnore.Contains(info.Name))
                    continue;

                //If we should ignore read only, skip it
                if (!CompareReadOnly && info.CanWrite == false)
                    continue;

                object objectValue1;
                object objectValue2;
                if (!IsValidIndexer(info, breadCrumb))
                {
                    objectValue1 = info.GetValue(object1, null);
                    objectValue2 = info.GetValue(object2, null);
                }
                else
                {
                    CompareIndexer(info, object1, object2, breadCrumb);
                    continue;
                }

                bool object1IsParent = objectValue1 != null && (objectValue1 == object1 || _parents.Contains(objectValue1));
                bool object2IsParent = objectValue2 != null && (objectValue2 == object2 || _parents.Contains(objectValue2));

                //Skip properties where both point to the corresponding parent
                if ((IsClass(info.PropertyType) || IsStruct(info.PropertyType)) && (object1IsParent && object2IsParent))
                {
                    continue;
                }

                string currentCrumb = AddBreadCrumb(breadCrumb, info.Name, string.Empty, -1);

                Compare(objectValue1, objectValue2, currentCrumb);

                if (Differences.Count >= MaxDifferences)
                    return;
            }
        }

        /// <summary>
        /// Determines whether [is valid indexer] [the specified information].
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Cannot compare objects with more than one indexer for object  + breadCrumb
        /// or
        /// Cannot compare objects with a non integer indexer for object  + breadCrumb
        /// or
        /// Indexer must have a corresponding Count property for object  + breadCrumb
        /// or
        /// Indexer must have a corresponding Count property that is an integer for object  + breadCrumb
        /// </exception>
        private bool IsValidIndexer(PropertyInfo info, string breadCrumb)
        {
            if (!info.CanWrite)
            {
                return true;
            }
            ParameterInfo[] indexers = info.GetIndexParameters();

            if (indexers.Length == 0)
            {
                return false;
            }

            if (indexers.Length > 1)
            {
                throw new Exception("Cannot compare objects with more than one indexer for object " + breadCrumb);
            }

            if (indexers[0].ParameterType != typeof(Int32))
            {
                throw new Exception("Cannot compare objects with a non integer indexer for object " + breadCrumb);
            }

            if (info.ReflectedType.GetProperty("Count") == null)
            {
                throw new Exception("Indexer must have a corresponding Count property for object " + breadCrumb);
            }

            if (info.ReflectedType.GetProperty("Count").PropertyType != typeof(Int32))
            {
                throw new Exception("Indexer must have a corresponding Count property that is an integer for object " + breadCrumb);
            }

            return true;
        }
        /// <summary>
        /// Compares the indexer.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        private void CompareIndexer(PropertyInfo info, object object1, object object2, string breadCrumb)
        {
            string currentCrumb;
            if (!info.CanWrite)
            {
                return;
            }
            var indexerCount1 = (int)info.ReflectedType.GetProperty("Count").GetGetMethod().Invoke(object1, new object[] { });
            var indexerCount2 = (int)info.ReflectedType.GetProperty("Count").GetGetMethod().Invoke(object2, new object[] { });

            //Indexers must be the same length
            if (indexerCount1 != indexerCount2)
            {
                currentCrumb = AddBreadCrumb(breadCrumb, info.Name, string.Empty, -1);
                Differences.Add(string.Format("object1{0}.Count != object2{0}.Count ({1},{2})", currentCrumb,
                                              indexerCount1, indexerCount2));

                if (Differences.Count >= MaxDifferences)
                    return;
            }

            // Run on indexer
            for (int i = 0; i < indexerCount1; i++)
            {
                currentCrumb = AddBreadCrumb(breadCrumb, info.Name, string.Empty, i);
                object objectValue1 = info.GetValue(object1, new object[] { i });
                object objectValue2 = info.GetValue(object2, new object[] { i });
                Compare(objectValue1, objectValue2, currentCrumb);

                if (Differences.Count >= MaxDifferences)
                    return;
            }
        }

        /// <summary>
        /// Compare a dictionary
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <exception cref="ArgumentNullException">
        /// object1
        /// or
        /// object2
        /// </exception>
        private void CompareIDictionary(object object1, object object2, string breadCrumb)
        {
            var iDict1 = object1 as IDictionary;
            var iDict2 = object2 as IDictionary;

            if (iDict1 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object1");

            if (iDict2 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object2");

            try
            {
                _parents.Add(object1);
                _parents.Add(object2);

                //Objects must be the same length
                if (iDict1.Count != iDict2.Count)
                {
                    Differences.Add(string.Format("object1{0}.Count != object2{0}.Count ({1},{2})", breadCrumb,
                                                  iDict1.Count, iDict2.Count));

                    if (Differences.Count >= MaxDifferences)
                        return;
                }

                IDictionaryEnumerator enumerator1 = iDict1.GetEnumerator();
                IDictionaryEnumerator enumerator2 = iDict2.GetEnumerator();

                while (enumerator1.MoveNext() && enumerator2.MoveNext())
                {
                    string currentBreadCrumb = AddBreadCrumb(breadCrumb, "Key", string.Empty, -1);

                    Compare(enumerator1.Key, enumerator2.Key, currentBreadCrumb);

                    if (Differences.Count >= MaxDifferences)
                        return;

                    currentBreadCrumb = AddBreadCrumb(breadCrumb, "Value", string.Empty, -1);

                    Compare(enumerator1.Value, enumerator2.Value, currentBreadCrumb);

                    if (Differences.Count >= MaxDifferences)
                        return;
                }
            }
            finally
            {
                _parents.Remove(object1);
                _parents.Remove(object2);
            }
        }

        /// <summary>
        /// Convert an object to a nicely formatted string
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private string cStr(object obj)
        {
            try
            {
                if (obj == null)
                    return "(null)";

                if (obj == DBNull.Value)
                    return "System.DBNull.Value";

                return obj.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// Compare an array or something that implements IList
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <param name="breadCrumb">The bread crumb.</param>
        /// <exception cref="ArgumentNullException">
        /// object1
        /// or
        /// object2
        /// </exception>
        private void CompareIList(object object1, object object2, string breadCrumb)
        {
            var ilist1 = object1 as IList;
            var ilist2 = object2 as IList;

            if (ilist1 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object1");

            if (ilist2 == null) //This should never happen, null check happens one level up
                throw new ArgumentNullException("object2");

            try
            {
                _parents.Add(object1);
                _parents.Add(object2);

                //Objects must be the same length
                if (ilist1.Count != ilist2.Count)
                {
                    Differences.Add(string.Format("object1{0}.Count != object2{0}.Count ({1},{2})", breadCrumb,
                                                  ilist1.Count, ilist2.Count));

                    if (Differences.Count >= MaxDifferences)
                        return;
                }

                IEnumerator enumerator1 = ilist1.GetEnumerator();
                IEnumerator enumerator2 = ilist2.GetEnumerator();
                int count = 0;

                while (enumerator1.MoveNext() && enumerator2.MoveNext())
                {
                    string currentBreadCrumb = AddBreadCrumb(breadCrumb, string.Empty, string.Empty, count);

                    Compare(enumerator1.Current, enumerator2.Current, currentBreadCrumb);

                    if (Differences.Count >= MaxDifferences)
                        return;

                    count++;
                }
            }
            finally
            {
                _parents.Remove(object1);
                _parents.Remove(object2);
            }
        }



        /// <summary>
        /// Add a breadcrumb to an existing breadcrumb
        /// </summary>
        /// <param name="existing">The existing.</param>
        /// <param name="name">The name.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private string AddBreadCrumb(string existing, string name, string extra, string index)
        {
            bool useIndex = !String.IsNullOrEmpty(index);
            bool useName = name.Length > 0;
            var sb = new StringBuilder();

            sb.Append(existing);

            if (useName)
            {
                sb.AppendFormat(".");
                sb.Append(name);
            }

            sb.Append(extra);

            if (useIndex)
            {
                int result;
                sb.AppendFormat(Int32.TryParse(index, out result) ? "[{0}]" : "[\"{0}\"]", index);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Add a breadcrumb to an existing breadcrumb
        /// </summary>
        /// <param name="existing">The existing.</param>
        /// <param name="name">The name.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private string AddBreadCrumb(string existing, string name, string extra, int index)
        {
            return AddBreadCrumb(existing, name, extra, index >= 0 ? index.ToString(CultureInfo.InvariantCulture) : null);
        }

        #endregion

    }
}