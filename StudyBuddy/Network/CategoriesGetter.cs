﻿using Newtonsoft.Json.Linq;
using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddy.Network
{
    class CategoriesGetter
    {
        public enum GetStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FieldsMissing
        }
        public delegate void GetCategoriesDelegate(GetStatus status, List<Category> categories);
        public GetCategoriesDelegate GetCategoriesResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getCategoriesThread;

        public CategoriesGetter() : this("") { }
        public CategoriesGetter(LocalUser user) : this(user.privateKey) { }
        public CategoriesGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public CategoriesGetter(GetCategoriesDelegate getCategoriesResult) : this("", getCategoriesResult) { }
        public CategoriesGetter(LocalUser user, GetCategoriesDelegate getCategoriesResult) : this(user.privateKey, getCategoriesResult) { }
        public CategoriesGetter(string privateKey, GetCategoriesDelegate getCategoriesResult) : this(privateKey)
        {
            GetCategoriesResult = getCategoriesResult;
        }

       public void get()
       {
            if (getCategoriesThread != null && getCategoriesThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getCategoriesThread = new Thread(getLogic);
            getCategoriesThread.Start();
       }

        private void getLogic()
        {
            JObject obj = new APICaller("getCategories.php").addParam("privateKey", PrivateKey).call();
            Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<Category> categories = new List<Category>();
                obj["categories"].ToList().ForEach((category) =>
                {
                    categories.Add(new Category
                    {
                        title = category["title"].ToString(),
                        description = category["description"].ToString(),
                        creatorUsername = category["username"].ToString()
                    });
                });
                GetCategoriesResult(GetStatus.Success, categories);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetCategoriesResult(status, null);
            }
        }
    }
}