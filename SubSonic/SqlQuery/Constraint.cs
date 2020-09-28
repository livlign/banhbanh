/*
 * SubSonic - http://subsonicproject.com
 * 
 * The contents of this file are subject to the Mozilla Public
 * License Version 1.1 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of
 * the License at http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
 * implied. See the License for the specific language governing
 * rights and limitations under the License.
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace SubSonic
{
    /// <summary>
    /// Where, And, Or
    /// </summary>
    public enum ConstraintType
    {
        /// <summary>
        /// WHERE operator
        /// </summary>
        Where,
        /// <summary>
        /// AND operator
        /// </summary>
        And,
        /// <summary>
        /// OR Operator
        /// </summary>
        Or
    }

    /// <summary>
    /// A Class for handling SQL Constraint generation
    /// </summary>
    public class Constraint
    {
        /// <summary>
        /// The query that this constraint is operating on
        /// </summary>
        public SqlQuery query;


        #region Factory methods

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="constraintColumnName">Name of the constraint column.</param>
        public Constraint(ConstraintType condition, string constraintColumnName)
        {
            Condition = condition;
            ColumnName = constraintColumnName;
            QualifiedColumnName = constraintColumnName;
            ConstructionFragment = constraintColumnName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="constraintColumnName">Name of the constraint column.</param>
        /// <param name="constraintQualifiedColumnName">Name of the constraint qualified column.</param>
        public Constraint(ConstraintType condition, string constraintColumnName, string constraintQualifiedColumnName)
        {
            Condition = condition;
            ColumnName = constraintColumnName;
            QualifiedColumnName = constraintQualifiedColumnName;
            ConstructionFragment = constraintColumnName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="constraintColumnName">Name of the constraint column.</param>
        /// <param name="constraintQualifiedColumnName">Name of the constraint qualified column.</param>
        /// <param name="constraintConstructionFragment">The constraint construction fragment.</param>
        public Constraint(ConstraintType condition, string constraintColumnName, string constraintQualifiedColumnName, string constraintConstructionFragment)
        {
            Condition = condition;
            ColumnName = constraintColumnName;
            QualifiedColumnName = constraintQualifiedColumnName;
            ConstructionFragment = constraintConstructionFragment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="constraintColumnName">Name of the constraint column.</param>
        /// <param name="sqlQuery">The SQL query.</param>
        public Constraint(ConstraintType condition, string constraintColumnName, SqlQuery sqlQuery)
        {
            Condition = condition;
            ColumnName = constraintColumnName;
            QualifiedColumnName = constraintColumnName;
            ConstructionFragment = constraintColumnName;
            query = sqlQuery;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="constraintColumnName">Name of the constraint column.</param>
        /// <param name="constraintQualifiedColumnName">Name of the constraint qualified column.</param>
        /// <param name="constraintConstructionFragment">The constraint construction fragment.</param>
        /// <param name="sqlQuery">The SQL query.</param>
        public Constraint(ConstraintType condition, string constraintColumnName, string constraintQualifiedColumnName, string constraintConstructionFragment, SqlQuery sqlQuery)
        {
            Condition = condition;
            ColumnName = constraintColumnName;
            QualifiedColumnName = constraintQualifiedColumnName;
            ConstructionFragment = constraintConstructionFragment;
            query = sqlQuery;
        }

        /// <summary>
        /// Wheres the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public static Constraint Where(string columnName)
        {
            return new Constraint(ConstraintType.Where, columnName);
        }

        /// <summary>
        /// Ands the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public static Constraint And(string columnName)
        {
            return new Constraint(ConstraintType.And, columnName);
        }

        /// <summary>
        /// Ors the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public static Constraint Or(string columnName)
        {
            return new Constraint(ConstraintType.Or, columnName);
        }

        #endregion


        #region props

        private TableSchema.TableColumn _column;
        private object _endValue;
        private Select _inSelect;
        private IEnumerable _inValues;
        private object _startValue;
        private string columnName;
        private Comparison comp;
        private ConstraintType condition = ConstraintType.Where;
        private string constructionFragment;
        private DbType dbType;
        private bool isAggregateValue;
        private string parameterName;
        private object paramValue;
        private string qualifiedColumnName;

        private string tableName;

        public TableSchema.TableColumn Column
        {
            get { return _column; }
            set { _column = value; }
        }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public ConstraintType Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>The name of the column.</value>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// Gets or sets the fully qualified name of the column.
        /// </summary>
        /// <value>The name of the column.</value>
        public string QualifiedColumnName
        {
            get { return qualifiedColumnName; }
            set { qualifiedColumnName = value; }
        }

        /// <summary>
        /// Gets or sets the string fragment used when assembling the text of query.
        /// </summary>
        /// <value>The construction fragment.</value>
        public string ConstructionFragment
        {
            get { return constructionFragment; }
            set { constructionFragment = value; }
        }

        /// <summary>
        /// Gets or sets the comparison.
        /// </summary>
        /// <value>The comparison.</value>
        public Comparison Comparison
        {
            get { return comp; }
            set { comp = value; }
        }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        /// <value>The parameter value.</value>
        public object ParameterValue
        {
            get { return paramValue; }
            set { paramValue = value; }
        }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>The start value.</value>
        public object StartValue
        {
            get { return _startValue; }
            set { _startValue = value; }
        }

        /// <summary>
        /// Gets or sets the end value.
        /// </summary>
        /// <value>The end value.</value>
        public object EndValue
        {
            get { return _endValue; }
            set { _endValue = value; }
        }

        /// <summary>
        /// Gets or sets the in values.
        /// </summary>
        /// <value>The in values.</value>
        public IEnumerable InValues
        {
            get { return _inValues; }
            set { _inValues = value; }
        }

        /// <summary>
        /// Gets or sets the in select.
        /// </summary>
        /// <value>The in select.</value>
        public Select InSelect
        {
            get { return _inSelect; }
            set { _inSelect = value; }
        }

        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        public string ParameterName
        {
            get { return parameterName ?? ColumnName; }
            set { parameterName = value; }
        }

        /// <summary>
        /// Gets or sets the type of the db.
        /// </summary>
        /// <value>The type of the db.</value>
        public DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this constraint is an Aggregate.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is aggregate; otherwise, <c>false</c>.
        /// </value>
        public bool IsAggregate
        {
            get { return isAggregateValue; }
            set { isAggregateValue = value; }
        }

        /// <summary>
        /// Gets the comparison operator.
        /// </summary>
        /// <param name="comp">The comp.</param>
        /// <returns></returns>
        public static string GetComparisonOperator(Comparison comp)
        {
            string sOut;
            switch(comp)
            {
                case Comparison.Blank:
                    sOut = SqlComparison.BLANK;
                    break;
                case Comparison.GreaterThan:
                    sOut = SqlComparison.GREATER;
                    break;
                case Comparison.GreaterOrEquals:
                    sOut = SqlComparison.GREATER_OR_EQUAL;
                    break;
                case Comparison.LessThan:
                    sOut = SqlComparison.LESS;
                    break;
                case Comparison.LessOrEquals:
                    sOut = SqlComparison.LESS_OR_EQUAL;
                    break;
                case Comparison.Like:
                    sOut = SqlComparison.LIKE;
                    break;
                case Comparison.NotEquals:
                    sOut = SqlComparison.NOT_EQUAL;
                    break;
                case Comparison.NotLike:
                    sOut = SqlComparison.NOT_LIKE;
                    break;
                case Comparison.Is:
                    sOut = SqlComparison.IS;
                    break;
                case Comparison.IsNot:
                    sOut = SqlComparison.IS_NOT;
                    break;
                case Comparison.OpenParentheses:
                    sOut = "(";
                    break;
                case Comparison.CloseParentheses:
                    sOut = ")";
                    break;
                case Comparison.In:
                    sOut = " IN ";
                    break;
                case Comparison.NotIn:
                    sOut = " NOT IN ";
                    break;
                default:
                    sOut = SqlComparison.EQUAL;
                    break;
            }
            return sOut;
        }

        #endregion


        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Creates a LIKE statement.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery Like(string val)
        {
            Comparison = Comparison.Like;
            ParameterValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);

            return query;
        }

        /// <summary>
        /// Creates a NOT LIKE statement
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery NotLike(string val)
        {
            Comparison = Comparison.NotLike;
            ParameterValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);

            return query;
        }

        /// <summary>
        /// Determines whether [is greater than] [the specified val].
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery IsGreaterThan(object val)
        {
            Comparison = Comparison.GreaterThan;
            ParameterValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);

            return query;
        }

        /// <summary>
        /// Determines whether [is greater than] [the specified val].
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery IsGreaterThanOrEqualTo(object val)
        {
            Comparison = Comparison.GreaterOrEquals;
            ParameterValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);

            return query;
        }

        /// <summary>
        /// Specifies a SQL IN statement using a nested Select statement
        /// </summary>
        /// <param name="selectQuery">The select query.</param>
        /// <returns></returns>
        public SqlQuery In(Select selectQuery)
        {
            //validate that there is only one column in the columnlist
            if(selectQuery.SelectColumnList.Length == 0 || selectQuery.SelectColumnList.Length > 1)
                throw new SqlQueryException("You must specify a column to return for the IN to be valid. Use Select(\"column\") to do this");

            InSelect = selectQuery;

            Comparison = Comparison.In;
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Specifies a SQL IN statement
        /// </summary>
        /// <param name="vals">Value array</param>
        /// <returns></returns>
        public SqlQuery In(IEnumerable vals)
        {
            if(vals == null)
                vals = new ArrayList();
            int counter = 0;
            IEnumerator enumer = vals.GetEnumerator();
            while(enumer.MoveNext())
                counter++;
            if(counter == 0)
            {
                vals = new ArrayList();
                ((ArrayList)vals).Add("NULL");
            }

            InValues = vals;
            Comparison = Comparison.In;
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Specifies a SQL IN statement
        /// </summary>
        /// <param name="vals">Value array</param>
        /// <returns></returns>
        public SqlQuery In(params object[] vals)
        {
            //this is trickery, since every time we send in a Select query, it will call this method
            //so we need to evaluate it, and call In(Select)
            //I don't like this hack, but don't see a way around it

            if(vals != null && vals.Length > 0)
            {
                if(vals[0].ToString().StartsWith("SELECT"))
                {
                    Select s = (Select)vals[0];
                    query = In(s);
                }
                else
                {
                    InValues = vals;
                    Comparison = Comparison.In;
                    query.Constraints.Add(this);
                }
            }
            else
            {
                ArrayList nullArray = new ArrayList();
                nullArray.Add("NULL");
                InValues = nullArray;
                Comparison = Comparison.In;
                query.Constraints.Add(this);
            }
            return query;
        }

        /// <summary>
        /// Specifies a SQL IN statement using a nested Select statement
        /// </summary>
        /// <param name="selectQuery">The select query.</param>
        /// <returns></returns>
        public SqlQuery NotIn(Select selectQuery)
        {
            //validate that there is only one column in the columnlist
            if(selectQuery.SelectColumnList.Length == 0 || selectQuery.SelectColumnList.Length > 1)
                throw new SqlQueryException("You must specify a column to return for the IN to be valid. Use Select(\"column\") to do this");

            InSelect = selectQuery;

            Comparison = Comparison.NotIn;
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Specifies a SQL Not IN statement
        /// </summary>
        /// <param name="vals">Value array</param>
        /// <returns></returns>
        public SqlQuery NotIn(IEnumerable vals)
        {
            if(vals == null)
                vals = new ArrayList();
            int counter = 0;
            IEnumerator enumer = vals.GetEnumerator();
            while(enumer.MoveNext())
                counter++;
            if(counter == 0)
            {
                vals = new ArrayList();
                ((ArrayList)vals).Add("NULL");
            }

            InValues = vals;
            Comparison = Comparison.NotIn;
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Specifies a SQL NOT IN statement
        /// </summary>
        /// <param name="vals">Value array</param>
        /// <returns></returns>
        public SqlQuery NotIn(params object[] vals)
        {
            if(vals != null && vals.Length > 0)
            {
                if(vals[0].ToString().StartsWith("SELECT"))
                {
                    Select s = (Select)vals[0];
                    query = NotIn(s);
                }
                else
                {
                    InValues = vals;
                    Comparison = Comparison.NotIn;
                    query.Constraints.Add(this);
                }
            }
            else
            {
                ArrayList nullArray = new ArrayList();
                nullArray.Add("NULL");
                InValues = nullArray;
                Comparison = Comparison.NotIn;
                query.Constraints.Add(this);
            }
            return query;
        }

        /// <summary>
        /// Determines whether [is less than] [the specified val].
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery IsLessThan(object val)
        {
            Comparison = Comparison.LessThan;
            paramValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Determines whether [is less than] [the specified val].
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery IsLessThanOrEqualTo(object val)
        {
            Comparison = Comparison.LessOrEquals;
            paramValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Determines whether [is not null] [the specified val].
        /// </summary>
        /// <returns></returns>
        public SqlQuery IsNotNull()
        {
            Comparison = Comparison.IsNot;
            paramValue = DBNull.Value;
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Determines whether the specified val is null.
        /// </summary>
        /// <returns></returns>
        public SqlQuery IsNull()
        {
            Comparison = Comparison.Is;
            paramValue = DBNull.Value;
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Determines whether [is between and] [the specified val1].
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns></returns>
        public SqlQuery IsBetweenAnd(object val1, object val2)
        {
            Comparison = Comparison.BetweenAnd;
            StartValue = val1;
            EndValue = val2;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val1);
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Determines whether [is equal to] [the specified val].
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery IsEqualTo(object val)
        {
            Comparison = Comparison.Equals;
            ParameterValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);
            return query;
        }

        /// <summary>
        /// Determines whether [is not equal to] [the specified val].
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public SqlQuery IsNotEqualTo(object val)
        {
            Comparison = Comparison.NotEquals;
            ParameterValue = val;
            DbType = query.GetConstraintDbType(TableName, ColumnName, val);
            query.Constraints.Add(this);
            return query;
        }
    }
}