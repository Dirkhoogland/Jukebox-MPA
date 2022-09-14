﻿using Jukebox_MPA_ASP.NET.Models;
using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Policy;


namespace Jukebox_MPA_ASP.NET.Controllers
{
    [BindProperties(SupportsGet = true)]
    public class DatabasecController1 : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;


        public DatabasecController1(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;

        }
        
        // user related functions
        //gets user to set into session as logged in
        public List<Users> getuser(int Id)
        {

            return _context.Users.Where(m => m.Id == Id).ToList();
        }
        //gets users for user page 
        public List<Users> getusers()
        {
            return _context.Users.Where(m => m.Id >= 0).ToList();
        }
        // create user 
        public void createuser(string name)
        {
           List<Users> namecheck = _context.Users.Where(m => m.Id >= 0).ToList();

            foreach(var users in namecheck)
            {
                if(users.Name == name)
                {
                    name = "duplicate";
                }
                else { }
            }

            if (name == "duplicate")
            {

            }
            else
            {
                _context.Users.Add(new Models.Database.Users() { Name = name });
                _context.SaveChanges();
            }
        }
        // deletes user
        public void deleteuser(int Id)
        {
            List<Users> removefunct = _context.Users.Where(a => a.Id == Id).ToList();
            _context.Users.Remove(removefunct[0]);
            _context.SaveChanges();
        }
        //----------------------------------------------------
        //playlist related functions

        public void uploadlist(List<Songs> songslist, string playlistname, string user)
        {
            _context.Playlistname.Add(new Models.Database.Playlistname(){ Playlistname1 = playlistname, User = user });
            _context.SaveChanges();
            List<Playlistname> name = _context.Playlistname.Where(a => a.Playlistname1 == playlistname).ToList();
            foreach(var item in songslist)
            {
                _context.Playlists.Add(new Models.Database.Playlists() {Song = item.Name, User = user, Playlist = name[0].Id });
                _context.SaveChanges();
            }
        }

        // deletes song from saved playlist
        public void deletesong(int Id)
        {
            List<Playlists> removefunct = _context.Playlists.Where(a => a.Id == Id).ToList();
            _context.Playlists.Remove(removefunct[0]);
            _context.SaveChanges();
        }


        //------------------------------------------
        //get functions
        // gets songs for view
        public List<Songs> GetSongs()
        {
            return _context.Songs.Where(m => m.Id >= 0).ToList();
        }
        // gets genre's for view
        public List<Genres> GetGenres()
        {
            return _context.Genres.Where(m => m.Id >= 0).ToList();
        }
        // gets playlist
        public List<Playlists> getplaylists(string user)
        {
            List<Playlists> playlists = _context.Playlists.Where(m => m.User == user).ToList();


            return playlists;
        }

        public List<Playlistname> getnames(string user)
        {
            List<Playlistname> playlists = _context.Playlistname.Where(m => m.User == user).ToList();


            return playlists;
        }
    }
}
