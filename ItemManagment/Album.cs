using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1

{
    internal class Album
    {

        private String name;
        private String artist;
        private int track;
        public Album()
        {
            Console.WriteLine("Starting the Album program!");
        }

        public void start()
        {
            readName();
            readArtist();
            readTrack();
            printMessage();
        }
        private void readName()
        {
            Console.WriteLine("What is the name of your favorit music album?.");
            do
            {
                this.name = Console.ReadLine();
                if (name == null || name.Length <= 1)
                {
                    Console.WriteLine("name can't be empty or one letters.");
                }
            } while (name.Equals(null) || name.Length <= 1);
        }


        private void readArtist()
        {
            Console.WriteLine("What is the name of the artist/band for " + this.name + " ?");
            do
            {
                this.artist = Console.ReadLine();
                if (artist == null || artist.Length <= 1)
                {
                    Console.WriteLine("Artist/band can't be empty or one letters.");
                }
            } while (artist.Equals(null) || artist.Length <= 1);
        }

        private void readTrack()
        {
            do
            {
                Console.WriteLine("How many tracks does " + this.name + " have ?");
                string strTrack = Console.ReadLine();
                this.track = int.Parse(strTrack); //converting from "9" to 9

                if (this.track <= 0)
                { Console.WriteLine("track must be greater than Zero."); }

            } while (this.track <= 0);
        }

        private void printMessage()
        {
            Console.WriteLine("\n Album name: " + this.name + "\n" +
              "Artist/band: " + this.artist + "\n" +
              "Number of tracks: " + this.track + "\n" +
              "Injoy listening! \n" +
              "Please press inter to start the next part:\n");
            String next = Console.ReadLine();

        }

        public void setName(string newName)
        {
            //check if new name is not empty
            if (newName != "")
                this.name = newName;

            printMessage();
        }

        public void setArtist(string newArtist)
        {
            //check if new artist is not empty
            if (newArtist != "")
                this.artist = newArtist;

            printMessage();
        }

        public void setTrack(int newTrack)
        {
            //check if new track is not 0
            if (newTrack != 0)
                this.track = newTrack;

            printMessage();
        }
        public String getName() { return this.name; }
        public String getArtist() { return this.artist; }
        public int getTrack() { return this.track; }




    }
}
