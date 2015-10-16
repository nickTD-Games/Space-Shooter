# Space Shooter

Second Unity game by following official [Space Shooter tutorial](http://unity3d.com/learn/tutorials/projects/space-shooter-tutorial).

## Setup

* Download Unity 5 for free ;)
* Setup [git-lfs](https://git-lfs.github.com)
* `git clone <url_of_this_repo>`

PS.
I haven't setup this project on another machine yet. If there's an issue, submit
an issue. XD

## GitHub LFS

Storing large files using GitHub's [Large File Storage](https://git-lfs.github.com).

See the list of extensions of large files in [.gitattributes](./.gitattributes).

## Components

* Lighting
  * 3 Lighting sources
* Components for an Entity
  * Transform (position, velocity)
  * `RigidBody` (Physics)
  * (Trigger) `Collider` (collision)
  * Script(s)
  * Audio(s)
* Enemies
  * Asteroid
  * Enemy Ship
    * Bolt
* Scripts
  * Destructions
    * [By Contact](./Assets/Scripts/DestroyByContact.cs)
    * [By Time](./Assets/Scripts/DestroyByTime.cs)
    * [By Boundary (anything goes out of the screen is destroyed)](./Assets/Scripts/DestroyByBoundary.cs)
  * Player
    * [Move](./Assets/Scripts/Mover.cs)
    * [Shoot](./Assets/Scripts/PlayerController.cs)
    * [Keep in the screen](./Assets/Scripts/PlayerController.cs)
  * Enemy
    * [Move](./Assets/Scripts/Mover.cs)
    * [Shoot](./Assets/Scripts/WeaponController.cs)
    * [Evasive Maneuver (Enemy Ship only)](./Assets/Scripts/EvasiveManeuver.cs)
    * [Random Rotation (Asteroid only)](./Assets/Scripts/RamdomRotator.cs)
  * [Infinite Scrolling Background](./Assets/Scripts/BGScroller.cs)
