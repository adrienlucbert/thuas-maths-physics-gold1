# 3D Cube

This is the first gold achievements for the Maths & Physics class in THUAS'
Game Development & Simulation minor.

## Instructions

Create a 3D cube that can rotate around all axis (x, y, z) and translate in all
directions (x, y, z), without using the built-in rotation or vector
functionality of Unity.  
This can be done by:

- using the mouse: with each change the corresponding transformation matrix is
determined and displayed
- manually changing the transformation matrix

### Result

<div align="center">
  <img src="./resources/demo.gif" alt="project demo"/>
  <p><i>Project demo</i></p>
</div>

The cube can rotate around all axis and be translated and scaled in all
directions. The transformation matrix is displayed and updated in real time,
and its values can be manually changed by clicking on them.

Transformation, scale and rotation sliders values can be changed by dragging the
slider left and right or by clicking on the slider value and modifying it
manually.

The transformation matrix is the exact same as the matrix resulting from a call
to [`UnityEngine.Matrix4x4.TRS`](https://docs.unity3d.com/ScriptReference/Matrix4x4.TRS.html).  
To compare the resulting transformation with Unity's built-in transformation,
toggle the reference. It draws a red cube, transformed using Unity's built-in
functions, on top of the white one, transformed using my own functions.

## Credits

This project is the work of [Adrien Lucbert](https://github.com/adrienlucbert),
and the Maths & Physics class was given by Rick Appleton.
