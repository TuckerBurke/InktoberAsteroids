# InktoberAsteroids
## Description
This project was intended to bring together knowledge of 2D movement and collision that we have covered thus far in the course. The assignment is to clone or mod the classic asteroids game.
## User Responsibilities
In this game, the user will have to fly around dodging and blowing up asteroids. One of three shields are lost when the player crashes into an asteroid. When the shield is consumed, the ship becomes invulnerable for a brief moment as the shields are up (prevents getting one shot). Once the three shields are consumed, the game is over. Points are accumulated for shooting asteroids. Player movement is A,S,D,W and Space to fire weapons. Press ESC to return to menu and to quit. Note: The game should be ran at 16:9 ratio.
## Above and Beyond 
Being my first real excursion into Unity, I’m impressed with how easy it is to add features to game objects. There is so much I want to do, it’s quickly becoming a deep rabbit hole.
First and most obvious, I hand drew and animated all of the assets and scanned them to give this game a certain look and feel. I was picturing the drawings from Napoleon Dynamite when I got started.
Added the invulnerable player state. When a shield is consumed, the ship cannot take further damage for a given duration of time. This prevents getting instantly nuked by colliding with multiple asteroids at the same time. Also enhancing the feeling of a shield being utilized. I have an animation for this as well which will be added in the next week.
Added additional asteroid variation. There are six separate prefabs with their own unique sprites and animations. Also, when they are instantiated, not only do they have unique location and direction, but they have randomly generated rotation and scale as well.
I play tested quite a bit trying to pick values that “feel” right. The acceleration and deceleration of the ship, how quickly / slowly the ship maneuvers, the range of speed for the asteroids was all heavily thought out.
I spend so much time commenting while developing I feel it should make an appearance in this section. I comment nearly every line of code, every variable declaration, class and function headings. My professor for the majority of my Computer Science courses was a Project Manager at Lockheed and taught us to comment to military specifications. I scale back a bit from that point.
## Caveats or Known Issues
To my knowledge there were no real errors or issues. Thinking in terms of components is a bit new to
me and I wonder if how I broke them up and where I decided to place certain functionality was
appropriate. Also, I left in unused start/update functions along with some unused variables. This is
because there is more being added this coming week. I’m not a fan how I handled data at this point. I’m
searching for references to objects to collide every frame. I’d love to add a custom data structure to
which objects are added / removed upon instantiation and destruction. I don’t think they’ll be time for
that though as there are many visual and gameplay aspects I intend to add this week.
