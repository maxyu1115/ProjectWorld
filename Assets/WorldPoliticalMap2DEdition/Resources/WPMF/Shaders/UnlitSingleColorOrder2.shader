﻿Shader "World Political Map 2D/Unlit Single Color Order 2" {
 
Properties {
    _Color ("Color", Color) = (1,1,1)
    _MainTex ("Texture", 2D) = ""//MAX!
}
 
SubShader {
    Color [_Color]
        Tags {
        "Queue"="Geometry+260"
        "RenderType"="Opaque"
    }
    Pass {
    }
}
 
}
