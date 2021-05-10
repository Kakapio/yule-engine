# yule
A 2D survival game intended to demonstrate technical ability in tackling a large project from scratch. This project was an enormous undertaking in that it represented the disciplines of software architecture, software design, software optimization, graphics programming, and game development. Features health, hunger, building, and digging. Everything is made from scratch, and I implemented my own engine in order to make this project possible. Monogame is a relatively bare-bones framework that mostly just includes the ability to load files (images, sound) and then render/play them back at run-time.

[Trello board can be found here](https://trello.com/b/3UcEQyGF/yule)

# Technical Information
* Entity Component Scene system. Everything in the world is made of an entity containing various components.
* Camera. A view matrix is generated based on a camera's position and zoom, which is then used to render the sprites.
* Tilemaps. A tile is composed of two ints describing its type and hits to break. A tilemap has a 2D array of tiles that are then used to render the world. Culling based on camera position is included to improve performance. Can support up to ~1,048,576,000 tiles.
