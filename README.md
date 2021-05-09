# yule
A 2D survival game intended to demonstrate technical ability in tackling a large project from scratch. Features health, hunger, building, and digging. Everything is made from scratch, and I implemented my own engine in order to make this project possible.

# Technical Information
* Entity Component Scene system. Everything in the world is made of an entity containing various components.
* Tilemaps. A tile is composed of two ints describing its type and hits to break. A tilemap has a 2D array of tiles that are then used to render the world. Culling is included to improve performance.
