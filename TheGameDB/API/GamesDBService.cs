using System;
using System.Xml;
using System.Collections.Generic;

namespace TheGameDB
{
    public class GamesDBService
    {
        public Game GetGame(string GameId)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetGame.php?id=" + GameId);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

            Game game = new Game();

            foreach (XmlNode node in nodes)
            {
                if(node.SelectSingleNode("id") != null)
                {
                    game.GameId = node.SelectSingleNode("id").InnerText;
                }
                else
                {
                    game.GameId = string.Empty;
                }

                if(node.SelectSingleNode("GameTitle") != null)
                {
                    game.GameTitle = node.SelectSingleNode("GameTitle").InnerText;
                }
                else
                {
                    game.GameId = string.Empty;
                }

                if(node.SelectSingleNode("PlatformId") != null)
                {
                    game.PlatformId = node.SelectSingleNode("PlatformId").InnerText;
                }
                else
                {
                    game.PlatformId = string.Empty;
                }

                if(node.SelectSingleNode("Platform") != null)
                {
                    game.Platform=node.SelectSingleNode("Platform").InnerText;
                }
                else
                {
                    game.Platform = string.Empty;
                }

                if(node.SelectSingleNode ("ReleaseDate") != null)
                {
                    game.ReleaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
                }
                else
                {
                    game.ReleaseDate = string.Empty;
                }

                if(node.SelectSingleNode("Overview") != null)
                {
                    game.OverView = node.SelectSingleNode("Overview").InnerText;
                }
                else
                {
                    game.OverView = string.Empty;
                }

                if(node.SelectSingleNode("ESRB") != null)
                {
                    game.ESRB = node.SelectSingleNode("ESRB").InnerText;
                }
                else
                {
                    game.ESRB = string.Empty;
                }

                if(node.SelectSingleNode("Players") != null)
                {
                    game.Players = node.SelectSingleNode("Players").InnerText;
                }
                else
                {
                    game.Players = string.Empty;
                }

                if(node.SelectSingleNode("Co-op") != null)
                {
                    game.CoOperative = node.SelectSingleNode("Co-op").InnerText;
                }
                else
                {
                    game.CoOperative = string.Empty;
                }

                if(node.SelectSingleNode("Publisher") != null)
                {
                    game.Publisher = node.SelectSingleNode("Publisher").InnerText;
                }
                else
                {
                    game.Publisher = string.Empty;
                }

                if(node.SelectSingleNode("Developer") != null)
                {
                    game.Developer = node.SelectSingleNode("Developer").InnerText;
                }
                else
                {
                    game.Developer = string.Empty;
                }

                if(node.SelectSingleNode("Rating") != null)
                {
                    game.Rating = node.SelectSingleNode("Rating").InnerText;
                }
                else
                {
                    game.Rating = string.Empty;
                }
            }

            nodes = doc.DocumentElement.SelectNodes("/Data/Game/Images/boxart");

            if(nodes != null)
            {
                if (nodes.Count == 2)
                {
                    if (nodes[1].FirstChild != null)
                    {
                        if (nodes[1].FirstChild.Value.Contains("front"))
                        {
                            game.Image = game.baseImgUrl + nodes[1].FirstChild.Value;
                        }
                    }
                }
                else if (nodes.Count == 1)
                {
                    if (nodes[0].FirstChild != null)
                    {
                        if (nodes[0].FirstChild.Value.Contains("front"))
                        {
                            game.Image = game.baseImgUrl + nodes[0].FirstChild.Value;
                        }
                    }
                }
                else
                {
                    game.Image = string.Empty;
                }
            }

            return game;
        }
            
        public List<GamesList> GetGameList(string SearchText)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetGamesList.php?name=" + SearchText);//test location

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

            List<GamesList> games = new List<GamesList>();

            foreach (XmlNode node in nodes)
            {
                GamesList game = new GamesList();

                game.GameId = node.SelectSingleNode("id").InnerText;
                game.GameTitle = node.SelectSingleNode("GameTitle").InnerText;
                if (node.SelectSingleNode ("ReleaseDate") != null) 
                {
                    game.ReleaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
                }
                game.Platform=node.SelectSingleNode("Platform").InnerText;

                games.Add(game);
            }
            return games;
        }
            
        public Platform GetPlatform(string PlatformId)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetPlatform.php?id=" + PlatformId);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Platform");

            Platform platform = new Platform();

            foreach (XmlNode node in nodes)
            {
                if (node.SelectSingleNode("id") != null)
                {
                    platform.PlatformId = node.SelectSingleNode("id").InnerText;
                }
                else
                {
                    platform.PlatformId = string.Empty;
                }

                if (node.SelectSingleNode("Platform") != null)
                {
                    platform.PlatformTitle = node.SelectSingleNode("Platform").InnerText;
                }
                else
                {
                    platform.PlatformTitle = string.Empty;
                }

                if (node.SelectSingleNode("overview") != null)
                {
                    platform.Overview=node.SelectSingleNode("overview").InnerText;
                }
                else
                {
                    platform.Overview = string.Empty;
                }

                if (node.SelectSingleNode("developer") != null)
                {
                    platform.Developer=node.SelectSingleNode("developer").InnerText;
                }
                else
                {
                    platform.Developer = string.Empty;
                }

                if (node.SelectSingleNode ("manufacturer") != null)
                {
                    platform.Manufacturer = node.SelectSingleNode ("manufacturer").InnerText;
                }
                else
                {
                    platform.Manufacturer = string.Empty;
                }

                if (node.SelectSingleNode("cpu") != null)
                {
                    platform.CPU = node.SelectSingleNode("cpu").InnerText;
                }
                else
                {
                    platform.CPU = string.Empty;
                }

                if (node.SelectSingleNode("memory") != null)
                {
                    platform.Memory = node.SelectSingleNode("memory").InnerText;
                }
                else
                {
                    platform.Memory = string.Empty;
                }

                if (node.SelectSingleNode("graphics") != null)
                {
                    platform.Graphics = node.SelectSingleNode("graphics").InnerText;
                }
                else
                {
                    platform.Graphics = string.Empty;
                }

                if (node.SelectSingleNode("sound") != null)
                {
                    platform.Sound = node.SelectSingleNode("sound").InnerText;
                }
                else
                {
                    platform.Sound = string.Empty;
                }

                if (node.SelectSingleNode("media") != null)
                {
                    platform.Media = node.SelectSingleNode("media").InnerText;
                }
                else
                {
                    platform.Media = string.Empty;
                }

                if (node.SelectSingleNode("maxcontrollers") != null)
                {
                    platform.MaxControllers = node.SelectSingleNode("maxcontrollers").InnerText;
                }
                else
                {
                    platform.MaxControllers = string.Empty;
                }

                if (node.SelectSingleNode("Rating") != null)
                {
                    platform.Rating = node.SelectSingleNode("Rating").InnerText;
                }
                else
                {
                    platform.Rating = string.Empty;
                }
            }
                
            nodes = doc.DocumentElement.SelectNodes("/Data/Platform/Images/boxart");

            if(nodes != null)
            {
                if (nodes.Count > 0)
                {
                    if (nodes[0].FirstChild != null)
                    {
                        if (nodes[0].FirstChild.Value.Contains("platform/boxart"))
                        {
                            platform.Image = platform.BaseImgUrl + nodes[0].FirstChild.Value;
                        }
                    }
                }
                else
                {
                    platform.Image = string.Empty;
                }
            }
            return platform;
        }
            
        public List<PlatformsList> GetPlatformsList()
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetPlatformsList.php");//test location

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Platforms/Platform");

            List<PlatformsList> platforms = new List<PlatformsList>();

            foreach (XmlNode node in nodes)
            {
                PlatformsList platform = new PlatformsList();

                platform.PlatformId = node.SelectSingleNode("id").InnerText;
                platform.PlatformName = node.SelectSingleNode("name").InnerText;
                if (node.SelectSingleNode ("alias") != null) 
                {
                    platform.PlatformAlias = node.SelectSingleNode ("alias").InnerText;
                }
                platforms.Add(platform);
            }
            return platforms;
        }
    }
}

