﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pathfinder_CharacterSheet.Dto;
using Pathfinder_CharacterSheet.Interfaces;




namespace Pathfinder_CharacterSheet.Repository
{
    public class UserRepository : IUserRepository

    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
           _context.Remove(user);
            return Save();
        }

        public ICollection<User> GetCharactersOfAUser(int charid)
        {
            return _context.Users.Where(u => u.Characters.Any(c => c.Id == charid)).ToList();
        }

        public ICollection<User> GetUser()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int userid)
        {
            return _context.Users.Where(u => u.Id == userid).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int userid)
        {
            return _context.Users.Any(u => u.Id == userid);
        }


    }
}
