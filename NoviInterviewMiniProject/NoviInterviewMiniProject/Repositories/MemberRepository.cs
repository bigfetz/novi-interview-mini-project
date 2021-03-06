﻿using Newtonsoft.Json;
using NoviInterviewMiniProject.Models;
using NoviInterviewMiniProject.Models.Entities;
using NoviInterviewMiniProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoviInterviewMiniProject.Repositories
{
    public interface IMemberRepository
    {
        Member GetByID(string id);

        IEnumerable<Member> GetAll();

        Member Add(Member entity);

        Member Update(Member entity);

        Member Delete(Member entity);
    }

    public class MemberRepository : Repository<Member>, IMemberRepository
    {

        public MemberRepository(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }
        
        /// <summary>
        /// Get member by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Member GetByID(string id)
        {
            string result = GetRequest("/Members/" + id);
            if (!string.IsNullOrEmpty(result))
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                return JsonConvert.DeserializeObject<Member>(result, jsonSerializerSettings);
            }

            return null;
        }

        /// <summary>
        /// Get active members
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Member> GetAll()
        {
            string result = GetRequest("/Members");
            if (!string.IsNullOrEmpty(result))
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                return JsonConvert.DeserializeObject<APIResult<Member>>(result, jsonSerializerSettings).Results.Where(x => x.Active);
            }

            return null;
        }

        public override Member Add(Member entity)
        {
            throw new NotImplementedException();
        }

        public override Member Update(Member entity)
        {
            throw new NotImplementedException();
        }

        public override Member Delete(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}