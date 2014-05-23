using System;
using System.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace TheGameDB
{
    public class GamesDBService
    {
        public void AddFavorite (Context Context,string GameId, string AccountIdentifier)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("http://thegamesdb.net/api/User_Favorites.php?=accountid=" + AccountIdentifier + "&type=add&gameid=" + GameId);
            }
            catch
            {
                var errorDialog = new AlertDialog.Builder(Context).SetTitle("Oops!").SetMessage("There was a problem Adding to favorites, please try again.").SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
            }
        }

        public void RemoveFavorite (Context Context,string GameId, string AccountIdentifier)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("http://thegamesdb.net/api/User_Favorites.php?=accountid=" + AccountIdentifier + "&type=remove&gameid=" + GameId);
            }
            catch
            {
                var errorDialog = new AlertDialog.Builder(Context).SetTitle("Oops!").SetMessage("There was a problem Removing from favorites, please try again.").SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
            }
        }

        public List<Game> GetFavoriteGameList(Context Context, string AccountIdentifier)
        {
            XmlDocument doc = new XmlDocument ();
            List<Game> gamesList = new List<Game>();

            try
            {
                doc.Load("http://thegamesdb.net/api/User_Favorites.php?=accountid=" + AccountIdentifier);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Favorites");

                foreach (XmlNode node in nodes)
                {
                    if(node.SelectSingleNode("Game") != null)
                    {
                        gamesList.Add(GetGame(Context, node.SelectSingleNode("Game").Value));
                    }
                }

                return gamesList;
            }
            catch
            {
                var errorDialog = new AlertDialog.Builder(Context).SetTitle("Oops!").SetMessage("There was a problem getting Favorites, please try again later.").SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();

                return gamesList;
            }
        }

        public Game GetGame(Context Context, string GameId)
        {
            XmlDocument doc = new XmlDocument ();
            Game game = new Game();

            try
            {
                doc.Load("http://thegamesdb.net/api/GetGame.php?id=" + GameId);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

               

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
            catch
            {
                var errorDialog = new AlertDialog.Builder(Context).SetTitle("Oops!").SetMessage("There was a problem getting game info, please try again later.").SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();

                game.Image = 
                    game.GameId =
                    game.GameTitle =
                    game.PlatformId =
                    game.Platform =
                    game.ReleaseDate =
                    game.OverView =
                    game.ESRB =
                    game.Players = 
                    game.CoOperative =
                    game.Publisher =
                    game.Developer =
                    game.Rating = string.Empty;

                return game;
            }
        }
            
        public List<GamesList> GetGameList(string SearchText)
        {
            XmlDocument doc = new XmlDocument ();
            List<GamesList> games = new List<GamesList>();

            try
            {
                doc.Load("http://thegamesdb.net/api/GetGamesList.php?name=" + SearchText);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

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
            catch
            {
                var game = new GamesList();
                game.GameTitle = "Sorry No Results for " + SearchText + ". Please try again later.";
                games.Add(game);
                return games;
            }
        }
            
        public Platform GetPlatform(Context Context, string PlatformId)
        {
            XmlDocument doc = new XmlDocument ();

            Platform platform = new Platform();

            try
            {
                doc.Load("http://thegamesdb.net/api/GetPlatform.php?id=" + PlatformId);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Platform");

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
            catch
            {
                var errorDialog = new AlertDialog.Builder(Context).SetTitle("Oops!").SetMessage("There was a problem getting Platform info, please try again later.").SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();

                platform.Image =
                    platform.PlatformId =
                    platform.PlatformTitle =
                    platform.Overview =
                    platform.Developer =
                    platform.Manufacturer =
                    platform.CPU =
                    platform.Memory =
                    platform.Graphics =
                    platform.Sound =
                    platform.Display =
                    platform.Media = 
                    platform.MaxControllers = 
                    platform.Rating = string.Empty;

                return platform;
            }
        }
            
        public List<PlatformsList> GetPlatformsList()
        {
            XmlDocument doc = new XmlDocument ();
            List<PlatformsList> platforms = new List<PlatformsList>();

            try
            {
                doc.Load("http://thegamesdb.net/api/GetPlatformsList.php");//test location

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Platforms/Platform");

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
            catch
            {
                var platform = new PlatformsList();
                platform.PlatformName = "Sorry there was a problem loading Platforms. Please try again later.";
                platforms.Add(platform);
                return platforms;
            }
        }
    }
}

