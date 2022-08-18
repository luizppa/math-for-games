# Math For Game Development

This is a collection of simple examples for math applications in game development. The examples here are based on a [playlist of video lessons](https://youtube.com/playlist?list=PLImQaTpSAdsD88wprTConznD1OY1EfK_V) from [Freya Holmér](https://www.youtube.com/c/Acegikmo) on YouTube.

- [Math For Game Development](#math-for-game-development)
  - [Content](#content)
  - [Examples](#examples)
    - [Radial Trigger](#radial-trigger)

## Content

The main subject of the examples is linear algebra. Here we will be talking about:
* Vectors
* Dot products
* Spaces

## Examples

In the simulation, tha player can move arround the game world with WASD and interact with the showcased applications of linear algebra. Next to each showcase, a panel explaining the mathematic behind it is shown, the explanations can also be found on this readme. The showcases are detailed below.

### Radial Trigger

A trigger that activates whenever the target object is within a certain radius. This techinque can be applied when you want to start a cutscene when a player approaches a certain object, or when you want a certain effect to be applied when the player enters an area. For example, in Valorant, Cypher's cage is a radial trigger that activates whenever an enemy player enters the effect area, triggering a sound allarm.

The way this trigger is calculates is by getting the difference between the vectors for the positions of the target and the trigger, the we calculate the magnitude of this vector defined by `|c| = sqrt(Σ ci²)`, where `c` is the difference vector, and `ci` is each entry of `c`. If the magnitude is smaller than the radius, the trigger is activated.

<img align="center" width="80%" src="./Assets/Sprites/game-mahts-radiual-trigger.png"/>

The resulting C# code is shown below.

```csharp
bool CheckTrigger()
{
  Vector3 distanceVector = (transform.position - triggerTarget.transform.position);
  float distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2) + Mathf.Pow(distanceVector.z, 2));
  // We calculate it manually for didatic reasons
  // however, unity has a built-in function for this
  // We could simply use "float distance = distanceVector.magnitude"
  return distance < radius;
}
```
