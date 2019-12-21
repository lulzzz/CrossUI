﻿using System.Runtime.InteropServices;
using CrossUI.SDL2.Structs;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_NumJoysticks_t();
        private static SDL_NumJoysticks_t s_sdl_numJoysticks = LoadFunction<SDL_NumJoysticks_t>("SDL_NumJoysticks");
        /// <summary>
        /// Count the number of joysticks attached to the system right now.
        /// </summary>
        public static int SDL_NumJoysticks() => s_sdl_numJoysticks();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_JoystickInstanceID_t(SDL_Joystick joystick);
        private static SDL_JoystickInstanceID_t s_sdl_joystickInstanceID = LoadFunction<SDL_JoystickInstanceID_t>("SDL_JoystickInstanceID");
        /// <summary>
        /// Returns the instance ID of the specified joystick on success or a negative error code on failure; call SDL_GetError() for more information.
        /// </summary>
        public static int SDL_JoystickInstanceID(SDL_Joystick joystick) => s_sdl_joystickInstanceID(joystick);
    }
}