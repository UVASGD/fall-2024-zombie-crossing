# Design Document 

## Introduction

### On Writing Design Documents
> Document your game design so that you and any other stakeholders in the game (the team,
management, etc.) know in as much detail as they need what the game is, what is needed to
complete it, and why it’s worth building.
Your design documentation serves as the embodiment of the vision for the game shared by the
team. It’s also ... a roadmap and guide for during development. This documentation covers the
qualities of the player’s experience, how the game behaves to support that, and the reasons
why you made various decisions along the way.
Note that all this is necessary even if you are alone on the project: six months from now it will
be very easy to forget why you wanted something a certain way. Having to re-think it later can
lead you to poor decisions or design thrashing (where you bounce between two lousy options
instead of finding an effective one).
In other words, your design documentation is both backward-looking and forward-looking: it
records the decisions you made and their rationales, and provides a map and a guide for
developing the game going forward.
> 
> Source: https://drive.google.com/file/d/17-51Uwxqle3DZVleir6OhDlWA_aerw5g/view

### Director Introduction
**Matthew Brown**: I’m Matthew Brown, a second-year studying computer science, and the author of this document. My aim is to one day be an _actual_ game director with a focus on gameplay programming. 
Last year, I signed up for QuickSilver (and did nothing, sorry!) and was the lead programmer for School of Nightmares. This will be my first directed game!
I created the original design and demo for the game and will be in charge of the overall game direction and technical side of development -- if we’re on schedule, I’ll help out with artistic things as well. 

**Aidan Mayhue**: Hey guys! My name is Aidan and I'm one of the directors on Zombie Crossing!! I'll be [one of] your point[s] of contact for all things art: 
music/writing/modeling/drawing.

>[!NOTE]
>When "I" is used, it's from Matthew's POV.

### Game Design Philosophy 
I don’t claim to have a full – or even fully informed – game design philosophy, but I subscribe to these few basic ideas: 
- Movement should be immediately responsive, and choices around movement controls should be centered only around accessibility (e.g. inverting axis controls should never be enforced). 
- When any significant portion
- I prefer games to be open-ended regardless of their linearity; the player should be given tools to explore the world through their own pace and means.

## Project Needs 

### Team 
I want to respect everyone’s time and interests to the best of my ability. After all, I am relying on free labor to help me see this vision through.

That’s why I designed this game to be something that I could make by myself in a semester at the very worst, but something that we could beautifully finish together at best. 

|Role|Importance|Reason|
|--|--|--|
|Programmers|Low|I would enforce proper, fair, coding guidelines that might be a turn off for beginners or people looking for a casual experience. These are important to me, and I am not willing to change them. I’m also capable of getting all programming tasks done alone, although proper help would be much appreciated.|
|2D Artists|Low|This game will not feature much 2D art beyond UI, and anything outside of that is not a priority. I can also tackle these.|
|3D Character Artists|Highest|The style of 3D art required is extremely specific. Having 3D artists would make enacting this vision _much_ easier.|
|Technical Artists|High|Make nice shaders, push the game’s atmosphere|
|Musicians|Medium|I would love help on this, but am fine with relying on free assets and things that I can compose.|
|Writers|High|Character dialogue is extremely important for a funny game. Higher quality dialogue would push that humor further. |
|Level Designers|Lowest|Level designers could help push the game's atmosphere, but, speaking from a point of inexperience,I think proper technical art is enough.|

### Finances 
I anticipate needing to pay for a  $100 Steam fee and occasional 3D-assets out of pocket; everything else should be able to be delivered in-house.

## High Level Design

### Concept 
Cultivate a cozy abode, while defending your residents from an oncoming zombie invasion -- and finding its cure.

### Genre
Simulation, Horror, Shooter 

### Target Audience
More mature audiences. This is not designed to be a realistic or sensical take on zombie or village survival, but just for people that would enjoy a comedic parody on both. 

### Unique Selling Point
The game creates a hilarious stylistic irony between the cuteness of Animal Crossing, violence akin to Doom, and gameplay of Project Zomboid. Further, unlike most simulation games that focus on crop cultivation, it focuses on fishing and foraging. 

## Product Design 

### Game Experience 
Everything about this game should be maximally funny, whether that is gameplay mechanics being stupidly unrealistic or the story just being downright dubious. 

For example, 

### Music Experience 
Quick interjection from Aidan: 

> Hey guys! As i start to compose music i wanted to touch base with you all about what kind of vibe and tone were going for. For the more animal crossing sections we’re shooting for more ambient and chill stuff (not unlike the animal crossing ost). For the combat sections, I’m planning on going full metal gear rising/astral chain/ devil may cry. I play guitar and am learning bass so that part will be a non issue, although if you’d like to collaborate on these tracks feel free to reach out, I’m very open to whatever talents you guys may have and open to whatever direction you’d like the song to go in.
I will soon have a doc prepared that’ll have examples so that it’s pretty clear about what vibe we’re going for, but just to make it clear, it’s more of a suggestion rather than a hard and fast rule
>
> https://docs.google.com/document/d/14v0qtnFAvR_CB-6VeLdKOaN9MN4NmANJOAplHaIbC3s/edit

UI SFX: 
https://kenney.nl/assets/interface-sounds

### Visual Experience 
Animal Crossing (GameCube) graphics with the visual fidelity of project Zomboid and low res textured games like Rune Factory: Tides of Destiny. A filter like in the first image is paramount. The game has only the date and time displayed in the UI. For the matter of health UI, there will be minimal to no health UI and it will be mostly diegetic. Dynamic objects (e.g. players, zombies) outside of your field of view will be fully occluded outside a small radius and static objects (e.g. the environment) will only be visible with a certain radius (so project zomboid). In classic Animal Crossing fashion, the playable character will be a human, and everything else is a furry or whatever. I also like the aesthetic of Metal Gear Solid 3 for the top-down perspective. 

### Point of View
The player is in charge of building an abode, located in the mountains, and defending it from zombies with various guns. The player should feel tense during these encounters, but the overall feel of the game should be hilarious apropos of its selling point. 

### Theme Statement
Good food (i.e. things) will stand the test of time and is worth sharing. 
Shorter: Good food is worth sharing.

### Plot
The player works to create a sanctuary for themselves and other survivors seeking refuge from a chaotic world overrun by zombies. The initial goal is to create a safe, cozy abode where people can rebuild their lives, relying on fishing, foraging, – and zombie meat as sustenance. The player must also regularly fend off zombie attacks. 

As the player rescues survivors, they slowly piece together that the zombies are actually former scientists who became infected right after discovering a legendary food recipe that can cure the zombie infection. The final goal, then, is to reproduce their findings by progressively acquiring rare ingredients while avoiding their same fate.

The in-game explanation for this zombie infection is that the people of this world (which, again are like Animal Crossing animals) went crazy because of a lack of good, tasty food. The “legendary” food recipe is probably just fish sticks or like a cheeseburger. 

### Monetization
The game will be completely free for any and all releases. 

### Platform 
The horizontal slice should be completely finished by the halfway point of the semester. The game is intended to be a shorter experience – around half an hour. I (Matthew Brown) will have copyright over the intellectual property. 

### Target Platform
This game will be written with Unity 6, which will be in beta during most production – but won’t be towards the end of development. Besides better features, it will also remove the splash screen. Yes, that is one of the biggest reasons. We will also use the Universal Render Pipeline. The game should target Windows via Steam and Itch.io, with support for controllers.

## System Design

### Core Loop
Collect supplies & key items for your abode > Attract zombies and survivors to your abode > Kill zombies

You would get new villagers mostly from finding them, which encourages you to explore. You may also be able to convert zombies into villagers. Villagers can also try to leave just like in animal crossing if they are unsatisfied and will take a tortimer like character’s aid to escape your village by boat if left unchecked for too long; this person can also sell you illegal items. 

Fishing should be maximally relaxing, and foraging should be more rewarding. Zombie flesh can also be consumed and honestly is the main food source. Think of it like Dungeon Meshi but just with zombies.

### Progression
The player will be engaged by increasing the “level” of its village – by getting more villagers, structures, and food – and by the progression of some simple and overarching plot. 

### Game Systems
Minimum Features in order of urgency: 
- Gun system 
- Zombies and basic zombie AI
- Health System
- NPCs
- Dialogue system
- Fishing and Foraging 
- Inventory
- POIs 
- Save system

Immediate Stretch Goals 
- Local Multiplayer 



