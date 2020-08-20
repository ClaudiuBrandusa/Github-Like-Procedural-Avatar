# Description

This project generates a procedural image avatar that resembles the github's default random avatar image.  
The algorithm used for the generation resembles a simplified version of the Perlin noise algorithm. (source: https://en.wikipedia.org/wiki/Perlin_noise)

# Tools used:
- Visual Studio 2019

# Packages used:  
- ```System.Drawing.Common``` at generating the image from the integer matrix.

# Generation process:  
In order to generate an image you have to create an object of type Generator which will take two arguments(width & height). 
This object will auto-generate an avatar and you can save it on your bin folder by calling Save("imageName") from the generator object.
You can generate another image at runtime if you call Generate from generator object. This method clear the image buffer and will generate another image. 
Do not forget to save it with an unique name otherwise it will overwrite the old image.

# How to use?
Firstly you will have to create an object of type Generator with two int parameters(10, 10 for example). Then you will be able to use the following commands.

# Commands:
- ```Generate()``` this method will generate a matrix of integer values of the size given at the generator's constructor.
- ```SetColor(string hexColor)``` will use the given hexadecimal color for the next image.
- ```SetDimensions(int width, int height)``` sets the resolution of the next images.
- ```Save(string filename)``` saves the generated matrix as a png image in the executable's folder using the name from filename parameter. 
- ```Export(Stream stream)``` same as the Save method but the difference here is that it's not saving the image on local storage but at runtime memory in a given stream. 
- ```ToString()``` returns the numerical representation of the matrix as a string.

# Results:  
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar.png)
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar2.png)
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar3.png)
![alt text](https://github.com/ClaudiuBrandusa/Github-Like-Procedural-Avatar/blob/master/Results/Avatar4.png)
