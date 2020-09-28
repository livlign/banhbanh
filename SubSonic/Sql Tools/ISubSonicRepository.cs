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

namespace SubSonic
{
    public interface ISubSonicRepository
    {
        DataProvider Provider { get; set; }
        void Delete<T>(string columnName, object columnValue) where T : RepositoryRecord<T>, new();
        Delete Delete();
        void Delete<T>(RepositoryRecord<T> item) where T : RepositoryRecord<T>, new();
        void Destroy<T>(string columnName, object value) where T : RepositoryRecord<T>, new();
        void Destroy<T>(RepositoryRecord<T> item) where T : RepositoryRecord<T>, new();
        T Get<T>(object primaryKeyValue) where T : RepositoryRecord<T>, new();
        T Get<T>(string columnName, object columnValue) where T : RepositoryRecord<T>, new();
        int Insert<T>(RepositoryRecord<T> item) where T : RepositoryRecord<T>, new();
        int Insert<T>(RepositoryRecord<T> item, string userName) where T : RepositoryRecord<T>, new();
        Insert Insert();
        InlineQuery Query();
        int Save<T>(RepositoryRecord<T> item) where T : RepositoryRecord<T>, new();
        int Save<T>(RepositoryRecord<T> item, string userName) where T : RepositoryRecord<T>, new();
        Select Select();
        Select Select(params Aggregate[] aggregates);
        Select Select(params string[] columns);
        Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new();
        Update Update<T>() where T : RecordBase<T>, new();
        int Update<T>(RepositoryRecord<T> item) where T : RepositoryRecord<T>, new();
        int Update<T>(RepositoryRecord<T> item, string userName) where T : RepositoryRecord<T>, new();

        int SaveAll<ItemType, ListType>(RepositoryList<ItemType, ListType> itemList)
            where ItemType : RepositoryRecord<ItemType>, new()
            where ListType : RepositoryList<ItemType, ListType>, new();

        int SaveAll<ItemType, ListType>(RepositoryList<ItemType, ListType> itemList, string userName)
            where ItemType : RepositoryRecord<ItemType>, new()
            where ListType : RepositoryList<ItemType, ListType>, new();
    }
}