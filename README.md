# Description

This project generates a procedural image avatar that resembles the github's default random avatar image.  
The algorithm used for the generation resembles a simplified version of the Perlin noise algorithm. (source: https://en.wikipedia.org/wiki/Perlin_noise)

# Tools used:
- Visual Studio 2019

# Packages used:  
- System.Drawing.Common at generating the image from the integer matrix.

# Generation process:  
In order to generate an image you have to create an object of type Generator which will take two arguments(width & height). 
This object will auto-generate an avatar and you can save it on your bin folder by calling Save("imageName") from the generator object.
You can generate another image at runtime if you call Generate from generator object. This method clear the image buffer and will generate another image. 
Do not forget to save it with an unique name otherwise it will overwrite the old image.

# Results:  
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar.png)
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar2.png)
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar3.png)
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar4.png)
