# Turtle's Dinner
**An immersive Unity game integrated with Arduino, centered around an environmental topic.**

![Image text](https://github.com/RebeccaSY/Turtle-Dinner/blob/main/images/gameview_night.png)  
![Image text](https://github.com/RebeccaSY/Turtle-Dinner/blob/main/images/gameview_day.png)  

In this game, players take control of a turtle's movement using an ultrasonic sensor, guiding it through the ocean to feed on jellyfish. However, the ocean is also littered with plastic bags that look similar to jellyfish, posing a threat to the turtle's health. It is important to avoid these plastic bags as they are harmful to the turtle's survival.

Eating jellyfish increases the turtle's health, while mistakenly colliding with plastic bags decreases its health. Failure to avoid an excessive number of plastic bags compared to the jellyfish eaten will lead to a failure of survival. As the game progresses, day and night cycles alternate. The plastic bags accumulate, with an increase in the turtle's movement speed, will result in a growing challenge.

This game aims to demonstrate the impact of plastic pollution on marine life. The player can see the pollution under a sea creature's eyes, understanding the need for sustainable practices to preserve our environment.

## Design Process

**Inspiration:** 
Discuss and diverge our thinking, determine the theme as ocean pollution.
![research](https://github.com/Qingyi-Www/Turtle-Dinner/assets/115076218/fd45a7c4-2894-4412-88e2-ae1fe06f1496)

**Research:** 
According to the research on marine pollution, we found that the plastic bags and jellyfish are very similar, which make sea turtles mistake them for jellyfish and eat them, many sea turtles died from this. So we set the game to the player control the sea turtle, and distinguish the difference between jellyfish and plastic bags, to make the correct judgment.


**Model:** 
We designed and built a ring-shaped terrain in order to realize that the turtles could always move forward (pulling up the terrain around and in the center, using materials to color the different positions of the model to distinguish between sand and rock parts). Afterwards, existing models (turtles, jellyfish, plastic bags, rocks, water plants, etc.) were used for the decoration of the scene.
![terrain](https://github.com/Qingyi-Www/Turtle-Dinner/assets/115076218/bc8d2c96-bcab-4ddc-a1cb-375fc459c8fa)

## Game Implementation

**Scenes:**  
There are 3 scenes - home page, gameplay interface, and gameover interface. The home page briefly introduces the game and features a "Start" button for users to begin playing. When entering the game, the gameplay interface displays the health bar, the number of consumed jellyfish, and the number of mistakenly consumed plastic bags. After the game ends, the user is directed to the gameover screen, where they can choose to restart the game or return to the home interface. Added a image animation to every scene achieve a natural scene transition.

**Player:**  
The player experiences the game from the perspective of a turtle, attempting to survive in the ocean. The script takes Arduino's output as player's height, forming variable-speed movement along a circular orbit.

**Consumption:**  
When collision detected, the item is considered as eaten by the turtle. The quantity of jellyfish and plastic bags eaten is stored and displayed on top of screen. A health bar on the top demonstrated the health condition by proportion. The color of the bar changes based on a customised colormap, with greener filling indicating better health and red warning for poor health.

**Spawner:**  
The spawner randomly initiate items within the range of player's orbit. 

**Light changes:** 
Create two directional lights: sun and moon, simulate day light and night light. Use 'transform.RotateAround' and 'transform.LookAt', causing the game object to orbit around the origin and gaze at it.

**Background Music:** 
Create a game object for the audio manager, use Awake() method, find all existing audio manager objects and destroy the excess ones to achieve continuous looping of the music.

## Demo

