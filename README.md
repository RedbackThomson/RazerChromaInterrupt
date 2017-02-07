# Razer Chroma Interrupt
### Source code for [Using Razer Chroma to Access Overwatch](https://medium.com/@RedbackThomson/chroma-overwatch-e41aab4c4404)

## Chroma Lighting Interrupt
Exports functions which match the Razer Chroma SDK exports in order to interrupt the calls from Overwatch to the Razer Chroma client.

## Chroma UI
Sets up a NamedPipeServerStream for which the Chroma Lighting Interrupt will connect. Displays a grid of coloured squares which represent the Chroma keyboard lighting effects.

## To Build
  - Install the NuGet packages
  - Build the solution
  - Replace ``C:\Windows\System32\RzChromaSDK64.dll`` with the DLL ChromaLightingInterrupt output
  - Start the Chroma UI executable
  - Run Overwatch
