using ProyectoSalvo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoSalvo.Models
{
    static public class DbInitializer
    {
        public static void Initialize(SalvoDatabaseContext context) //static nos permite utilizarla sin
        {                                                             //    instanciarla
            if (!context.Ship.Any())
            {
                var players = new Player[]
                {
                   new Player{Email = "luis@gmail.com", Password = "24"},
                   new Player{Email = "daniel@gmail.com",Password = "42"},
                   new Player{Email = "maria@gmail.com",Password = "kb"},
                   new Player{Email = "ana@gmail.com",Password = "mole"}
                };
                foreach (Player p in players)
                {
                    context.Player.Add(p);
                }
                context.SaveChanges();
            }
            if (!context.Game.Any())
            {
                var games = new Game[]
                {
                   new Game{CreationDate = DateTime.Now},
                   new Game{CreationDate = DateTime.Now},
                   new Game{CreationDate = DateTime.Now.AddHours(1)},
                   new Game{CreationDate = DateTime.Now.AddHours(2)},
                   new Game{CreationDate = DateTime.Now.AddHours(3)},
                   new Game{CreationDate = DateTime.Now},
                   new Game{CreationDate = DateTime.Now},
                   new Game{CreationDate = DateTime.Now},
                };
                foreach (Game g in games)
                {
                    context.Game.Add(g);
                }
                context.SaveChanges();
            }

            if (!context.GamePlayer.Any())
            {
                Game game1 = context.Game.Find(1L);
                Game game2 = context.Game.Find(2L);
                Game game3 = context.Game.Find(3L);
                Game game4 = context.Game.Find(4L);
                Game game5 = context.Game.Find(5L);
                Game game6 = context.Game.Find(6L);
                Game game7 = context.Game.Find(7L);
                Game game8 = context.Game.Find(8L);
                Player jbauer = context.Player.Find(1L);
                Player obrian = context.Player.Find(2L);
                Player kbauer = context.Player.Find(3L);
                Player almeida = context.Player.Find(4L);
                var gamesPlayers = new GamePlayer[]
                {
                   new GamePlayer{JoinDate=DateTime.Now, Game = game1, Player = jbauer},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game1, Player = obrian},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game2, Player = jbauer},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game2, Player = obrian},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game3, Player = obrian},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game3, Player = almeida},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game4, Player = obrian},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game4, Player = jbauer},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game5, Player = almeida},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game5, Player = jbauer},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game6, Player = kbauer},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game7, Player = almeida},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game8, Player = kbauer},
                   new GamePlayer{JoinDate=DateTime.Now, Game = game8, Player = almeida},
                };
                foreach (GamePlayer gp in gamesPlayers)
                {
                    context.GamePlayer.Add(gp);
                }
                context.SaveChanges();
            }
            if (!context.Ship.Any())
            {
                GamePlayer gp1 = context.GamePlayer.Find(1L);
                GamePlayer gp2 = context.GamePlayer.Find(2L);
                GamePlayer gp3 = context.GamePlayer.Find(3L);
                GamePlayer gp4 = context.GamePlayer.Find(4L);
                GamePlayer gp5 = context.GamePlayer.Find(5L);
                GamePlayer gp6 = context.GamePlayer.Find(6L);
                GamePlayer gp7 = context.GamePlayer.Find(7L);
                GamePlayer gp8 = context.GamePlayer.Find(8L);
                var ships = new Ship[]
                {
                   new Ship   {Type = "Carrier", Lenght = 5, GamePlayer = gp1
                   , Locations = new ShipLocation[] {
                       new ShipLocation { Location = "B5"},
                        new ShipLocation { Location = "C5"},
                         new ShipLocation { Location = "D5"}
                        }
                   },
                    new Ship   {Type = "Carrier", Lenght = 5, GamePlayer = gp2
                   , Locations = new ShipLocation[] {
                       new ShipLocation { Location = "B5"},
                        new ShipLocation { Location = "C5"},
                         new ShipLocation { Location = "D5"}
                        }
                    
                   }
                };
                foreach (Ship ship in ships)
                {
                    context.Ship.Add(ship);
                }
                context.SaveChanges();
            }
            //implementar salvos
            if (!context.Salvos.Any())
            {
                GamePlayer gamePlayer1 = context.GamePlayer.Find(1L);
                GamePlayer gamePlayer2 = context.GamePlayer.Find(2L);
                GamePlayer gamePlayer3 = context.GamePlayer.Find(3L);
                GamePlayer gamePlayer4 = context.GamePlayer.Find(4L);
                GamePlayer gamePlayer5 = context.GamePlayer.Find(5L);
                GamePlayer gamePlayer6 = context.GamePlayer.Find(6L);
                GamePlayer gamePlayer7 = context.GamePlayer.Find(7L);
                GamePlayer gamePlayer8 = context.GamePlayer.Find(8L);
                GamePlayer gamePlayer9 = context.GamePlayer.Find(9L);
                GamePlayer gamePlayer10 = context.GamePlayer.Find(10L);
                GamePlayer gamePlayer11 = context.GamePlayer.Find(11L);
                GamePlayer gamePlayer12 = context.GamePlayer.Find(12L);
                GamePlayer gamePlayer13 = context.GamePlayer.Find(13L);
                var salvos = new Salvo[]
                {
                    //jbauer gp1
                    new Salvo{Turn = 1, GamePlayer = gamePlayer1, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "B5" },
                            new SalvoLocation { Location = "C5" },
                            new SalvoLocation { Location = "F1" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer1, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "F2" },
                            new SalvoLocation { Location = "D5" }
                        }
                    },
                    //cobrian gp2
                    new Salvo{Turn = 1, GamePlayer = gamePlayer2, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "B4" },
                            new SalvoLocation { Location = "B5" },
                            new SalvoLocation { Location = "B6" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer2, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "E1" },
                            new SalvoLocation { Location = "H3" },
                            new SalvoLocation { Location = "A2" }
                        }
                    },
                    //jbauer gp3
                    new Salvo{Turn = 1, GamePlayer = gamePlayer3, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "A2" },
                            new SalvoLocation { Location = "A4" },
                            new SalvoLocation { Location = "G6" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer3, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "A3" },
                            new SalvoLocation { Location = "H6" }
                        }
                    },
                    //obrian gp4
                    new Salvo{Turn = 1, GamePlayer = gamePlayer4, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "B5" },
                            new SalvoLocation { Location = "D5" },
                            new SalvoLocation { Location = "C7" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer4, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "C5" },
                            new SalvoLocation { Location = "C6" }
                        }
                    },
                    //obrian gp5
                    new Salvo{Turn = 1, GamePlayer = gamePlayer5, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "G6" },
                            new SalvoLocation { Location = "H6" },
                            new SalvoLocation { Location = "A4" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer5, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "A2" },
                            new SalvoLocation { Location = "A3" },
                            new SalvoLocation { Location = "D8" }
                        }
                    },
                    //talmeida gp6
                    new Salvo{Turn = 1, GamePlayer = gamePlayer6, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "H1" },
                            new SalvoLocation { Location = "H2" },
                            new SalvoLocation { Location = "H3" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer6, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "E1" },
                            new SalvoLocation { Location = "F2" },
                            new SalvoLocation { Location = "G3" }
                        }
                    },
                    //obrian gp7
                    new Salvo{Turn = 1, GamePlayer = gamePlayer7, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "A3" },
                            new SalvoLocation { Location = "A4" },
                            new SalvoLocation { Location = "F7" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer7, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "A2" },
                            new SalvoLocation { Location = "G6" },
                            new SalvoLocation { Location = "H6" }
                        }
                    },
                    //jbauer gp8
                    new Salvo{Turn = 1, GamePlayer = gamePlayer8, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "B5" },
                            new SalvoLocation { Location = "C6" },
                            new SalvoLocation { Location = "H1" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer8, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "C5" },
                            new SalvoLocation { Location = "C7" },
                            new SalvoLocation { Location = "D5" }
                        }
                    },
                    //talmeida gp9
                    new Salvo{Turn = 1, GamePlayer = gamePlayer9, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "A1" },
                            new SalvoLocation { Location = "A2" },
                            new SalvoLocation { Location = "A3" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer9, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "G6" },
                            new SalvoLocation { Location = "G7" },
                            new SalvoLocation { Location = "G8" }
                        }
                    },
                    //jbauer gp10
                    new Salvo{Turn = 1, GamePlayer = gamePlayer10, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "B5" },
                            new SalvoLocation { Location = "B6" },
                            new SalvoLocation { Location = "C7" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gamePlayer10, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "C6" },
                            new SalvoLocation { Location = "D6" },
                            new SalvoLocation { Location = "E6" }
                        }
                    },
                    new Salvo{Turn = 3, GamePlayer = gamePlayer10, Locations = new SalvoLocation[] {
                            new SalvoLocation { Location = "H1" },
                            new SalvoLocation { Location = "H8" }
                        }
                    },
                };
                foreach (Salvo salvo in salvos)
                {
                    context.Salvos.Add(salvo);
                }
                context.SaveChanges();
            }
            
            if (!context.Score.Any())
            {
                Game game1 = context.Game.Find(1L);
                Game game2 = context.Game.Find(2L);
                Game game3 = context.Game.Find(3L);
                Game game4 = context.Game.Find(4L);
                Game game5 = context.Game.Find(5L);
                Game game6 = context.Game.Find(6L);
                Game game7 = context.Game.Find(7L);
                Game game8 = context.Game.Find(8L);

                Player jbauer = context.Player.Find(1L);
                Player obrian = context.Player.Find(2L);
                Player kbauer = context.Player.Find(3L);
                Player almeida = context.Player.Find(4L);

                var scores = new Score[]
                {
                    //jbauer gp1
                    new Score {
                        Game = game1,
                        Player = jbauer,
                        FinishDate = DateTime.Now,
                        Point = 1
                    },

                    //obrian gp2
                    new Score {
                        Game = game1,
                        Player = obrian,
                        FinishDate = DateTime.Now,
                        Point = 0
                    },

                    //jbauer gp3
                    new Score {
                        Game = game2,
                        Player = jbauer,
                        FinishDate = DateTime.Now,
                        Point = 0.5
                    },

                    //obrian gp4
                    new Score {
                        Game = game2,
                        Player = obrian,
                        FinishDate = DateTime.Now,
                        Point = 0.5
                    },

                    //obrian gp5
                    new Score {
                        Game = game3,
                        Player = obrian,
                        FinishDate = DateTime.Now,
                        Point = 0
                    },

                    //almeida gp6
                    new Score {
                        Game = game3,
                        Player = almeida,
                        FinishDate = DateTime.Now,
                        Point = 1
                    },

                    //obrian gp7
                    new Score {
                        Game = game4,
                        Player = obrian,
                        FinishDate = DateTime.Now,
                        Point = 0.5
                    },

                    //jbauer gp8
                    new Score {
                        Game = game4,
                        Player = jbauer,
                        FinishDate = DateTime.Now,
                        Point = 0.5
                    },
                };

                foreach (Score score in scores)
                {
                    context.Score.Add(score);
                }

                context.SaveChanges();
            }
       }
    }
}
