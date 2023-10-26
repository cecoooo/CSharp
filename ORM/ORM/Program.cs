using Microsoft.EntityFrameworkCore;
using ORM;
using ORM.Models;

ApplicationDBContext db = new ApplicationDBContext();

db.Towns.Add(new Town("New new York", 3));
