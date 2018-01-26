#version 450 core

layout(location = 0) in vec4 position;
layout(location = 1) in vec4 color;

layout(location = 20) uniform  mat4 projection;

out vec4 vs_color;

void main(void)
{
	gl_Position = projection * position;
	vs_color = color;
}