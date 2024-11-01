This fork is to install ACE on a raspberry pi 5 running Ubuntu Server 24.04.1 LTS (64-bit). Eventually I would like to create an expandable Pi cluster. This is really just a way for me to remember "how did I do that again?", but I figured that I would share this in case anyone else is looking to do the same. The official ACE repo has a docker container for the raspberry pi 5, I've always had trouble with docker which is why this exists.

Image SD Card with Raspberry Pi Imager (https://www.raspberrypi.com/software/). Choose Other general-purpose OS -> Ubuntu -> Ubuntu Server 24.04.1 LTS (64-bit).
### Upgrade the system
sudo apt update && sudo apt upgrade -y

sudo reboot now
### Install .Net SDK 8.0
sudo apt install -y dotnet-sdk-8.0
### Install MariaDB Server
sudo apt install mariadb-server

sudo mysql_secure_installation
### Create Databases
sudo mysql

CREATE DATABASE ace_auth;

CREATE DATABASE ace_shard;

CREATE DATABASE ace_world;

CREATE USER 'YOUR_DB_USER'@localhost IDENTIFIED BY 'YOUR_DB_PASSWORD';

GRANT ALL PRIVILEGES ON ace_auth.* TO 'YOUR_DB_USER'@'localhost';

GRANT ALL PRIVILEGES ON ace_shard.* TO 'YOUR_DB_USER'@'localhost';

GRANT ALL PRIVILEGES ON ace_world.* TO 'YOUR_DB_USER'@'localhost';

FLUSH PRIVILEGES;

QUIT;
### Get Updated DAT's
sudo apt-get install -y megatools p7zip-full

megadl 'https://mega.nz/#!Q98n0BiR!p5IugPS8ZkQ7uX2A_LdN3Un2_wMX4gZBHowgs1Qomng'

7z x ac-updates.zip -oDAT *.dat

rm ac-updates.zip
### Clone ACE-Pi5 Repo
git clone https://github.com/oXL0C0Xo/ACE-Pi5.git
### Build Server
cd /home/YOUR_LINUX_USER/ACE-Pi5/Source

dotnet build
### Run the Server
cd /home/YOUR_LINUX_USER/ACE-Pi5/Source/ACE.Server/bin/ARM64/Debug/net8.0

dotnet ACE.Server.dll

The first run of the server you will get the following prompts:

Enter the name for your World (default: "ACEmulator"): YOUR_WORLD_NAME

Enter the Host address for your World (default: "0.0.0.0"): ENTER_KEY

Enter the Port for your World (default: "9000"): ENTER_KEY

Enter the directory location for your DAT files (default: "c:\ACE\Dats\"): /home/YOUR_LINUX_USER/DAT

Enter the database name for your authentication database (default: "ace_auth"): ENTER_KEY

Enter the database name for your shard database (default: "ace_shard"): ENTER_KEY

Enter the database name for your world database (default: "ace_world"): ENTER_KEY

Typically, all three databases will be on the same SQL server, is this how you want to proceed? (Y/n) Y

Enter the Host address for your SQL server (default: "127.0.0.1"): ENTER_KEY

Enter the Port for your SQL server (default: "3306"): ENTER_KEY

Typically, all three databases will be on the using the same SQL server credentials, is this how you want to proceed? (Y/n) Y

Enter the username for your SQL server (default: "root"): YOUR_DB_USER

Enter the password for your SQL server (default: ""): YOUR_DB_PASSWORD

Do you want to ACEmulator to attempt to initialize your SQL databases? This will erase any existing ACEmulator specific databases that may already exist on the server (Y/n): Y

Do you want to download the latest world database and import it? (Y/n): Y

### Update the Server
cd /home/YOUR_LINUX_USER/ACE-Pi5

git pull origin

cd /home/YOUR_LINUX_USER/ACE-Pi5/Source

dotnet build

