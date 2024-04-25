<h1>Introduction</h1>
Eclipse Exodus is my 3D Unity platformer shooter game developed for Professional Practice in IT. In this 
game you are a strange alien in a sci-fi landscape where you are the monster, and the ship crew are the 
enemies that hunt you down. Akin to the 1979 classic Film “Alien” but from the other way round. The 
player must survive the crew, shooting them down and traversing their space environment to steal machine 
parts and reach the exit. As you kill, you build up mass, increasing your player size visually. The game 
features a carefully built 3D movement and interaction system, 3D Map design, a camera state system, 
Enemy AI states and a leaderboard. It also uses Unity audio systems and animations.
<br>

<h1>Technologies Used</h1>
Unity’s game design engine was the main technology used throughout the development of this project, 
along with C# as the programming language for scripting. Git Hub and Unity source control were vital for 
asset management and version control and collaboration with my supervisor. A pre-built WebGL 
Leaderboard was also imported and then integrated into my project through my own C# script. Various 
Unity technologies were used such as Cinemachine which aided in the development of my Camera system 
and Unity’s AI import which allowed me to develop my Enemy’s with AI traversal on Nav meshes and 
dynamic states.
<br>

<h1>Architecture</h1>
The Player Controller script and the Session controller are the core of this games architectural structure with a 
constant back and forth between the two to manage asynchronous scene loading and session persistence-based 
features like points, lives etc. The session manager includes a UI Canvas with a dynamic lives’ container (adjusting the 
lives visual as lives are lost) and a dynamic progress bar for your current mass. These all interact in a synced manner 
with the session controller and through that the player.
<br>

The player controller provides movement to the player object along with various forms of projectile generation for 
shooting, the player controller also implements various children entities. This includes an imported Mimic object that 
has been edited and adapted to work within my player movement system. This provides a dynamic visual for the 
movement using various ray casts, coroutines and vector setups for the leg movement of the player. The player 
interacts with various Cinemachine camera objects that are used to make these various camera states the player can 
swap between mid-game: basic, shooter and Top Down.
<br>
A spawn manager and spawn points are used to generate our enemy soldier entities. These enemies use a Unity AI 
system for Nav Mesh traversal that through my script allows them to switch between 3 states based on 
circumstances: Patrolling, Chasing and Attacking. They can patrol an area continuously until they come in range of a 
player, then proceed to close the distance by chasing a player then attack with a projectile shooting implementation. 
Other portions of the architecture include a leaderboard pulled down from a WebGL, an Audio Manager entity used 
amongst the architecture for background Music, steps, shooting, UI sounds etc and powerup entities that interact 
with the scene to cause affects.

