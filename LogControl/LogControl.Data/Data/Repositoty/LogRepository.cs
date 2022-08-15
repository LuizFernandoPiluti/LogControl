using LogControl.Model.Interface.Data;
using LogControl.Model.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LogControl.Data.Data.Repositoty
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _mongoCollection;

        public LogRepository(IDataBaseConfig dataBaseConfig)
        {

            var mongoClient = new MongoClient(dataBaseConfig.ConnecionString);
            var database = mongoClient.GetDatabase(dataBaseConfig.DataBaseName);
            _mongoCollection = database.GetCollection<Log>("Log");
        }
        public Log Get(string id)
        {
            var log = new Log();
            try
            {
                log = _mongoCollection.Find(log => log.Id == id).FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return log;
        }

        public List<Log> GetAll()
        {
            var logs = new List<Log>();
            try
            {
                logs =  _mongoCollection.Find(log => true).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return logs;
        }

        public bool Insert(Log log)
        {
            bool status = false;
            try
            {
                _mongoCollection.InsertOne(log);

                status = true;
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }

            return status;
        }

        public Log Update(string id, Log newLog)
        {
            var log = new Log();
            try
            {
                _mongoCollection.ReplaceOne(log => log.Id == id, newLog);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return log;
        }
    }
}
