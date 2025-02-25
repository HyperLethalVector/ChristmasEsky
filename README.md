# ProjectEsky-UnityIntegration

Welcome to Project Esky! 

Project Esky aims to be the OpenSource, software companion to allow developing with the Deck X/North Star Display system out of the box! 
(Utilizing the Intel Realsense t265/1 or a ZED system)

This includes a unity package that handles
- Rendering (with V2 undistortion via a separate OpenGL Renderer)
- MRTK Integration with the Leap Motion controller (aligned with the user's view)
- 6DoF Head Tracking + Re-Localization events (Save map, load map, add persistence, callbacks, ect.)
- Spatial mapping (Via the ZED SDK, with future plans to rip out the point cloud for t265 to allow scene authoring/phantom model interactions)
- Object Persistence (Via the t265/1 or ZED SDK <Available in another repo, TBA>)

Required Software:
- Unity 2019.4.X
- LeapMotion libraries (I recommend the latest orion beta)
- Visual Studio C++ Redistributable: https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads
- Microsoft Direct X End-User Redistributable: https://www.microsoft.com/en-gb/download/confirmation.aspx?id=35
- Windows (Sadly, for now.....)


Currently, the v2 + leapmotion + T265 calibration in this project has been pre calibrated and setup, 
It utilizes a DeckX variation of the Project North-Star display, purchasable here: https://www.smart-prototyping.com/AR-VR-MR-XR 
Your headset, provided there is little warping in the 3D print/sensor arrangement, should be good to go from here!

If you want to improve the visual quality, calibrate your NS using the v2 method described here: https://project-north-star.gitbook.io/project-north-star/calibration/calibration-v2

Copy/Paste the 4 float arrays generated by the northstar v2 calibration, into /DisplayCalibration.json
(Warning, DO NOT JUST COPY AND PASTE THE FILE, or you'll need to re-add the extra variables I set, at least until the calibration method includes these variables in the JSON file)

You can perform 6DOF and LeapMotion hand calibration in the Assets/Scenes/LMHandAligner.unity scene

Load up the project in unity, load /Assets/Scenes/HandInteractionExamples.unity

Adjust the DisplaySettings.json file with the window position x/y, and resolution of your render textures
if your image isn't clear, try toggling the 'requires rotation' boolean (to rotate the cameras 90 degrees)
with any luck you, when you hit play, you should see an undistorted stereo pair on your headset.

You can now adjust the offset for the left and right eye, using the DisplaySettings.json file, 
you should try your best to adjust the offsets so that the objects in the scene overlap perfectly!

For hand-aligning the leapmotion controller, you can use the tool in Assets/Scenes/LMCalibration.unity

<TODO: Add instructions for relocalization>
<TODO: Integrate stabilizer, it's working but buggy due to tracker jitter>

KNOWN ISSUES:
- The relocalizer is known to be a bit finnicky, try reloading the map onto the t265
- With unity, the editor might freeze, if it does, please unplug your realsense then plug it back in (or if you're running a deck X, hold the two buttons to power cycle the t261) 

If you wish to ask questions, please join the North Star Community on Discord! 
https://discord.gg/fPza2G


Quick FAQ:

1) Hey, I see some extra hlsl shaders in the root directory, what are these for?
Actually these are what powers the magic behind the V2 renderer system, I am passing a render texture pointer to a separate DirectX instance! Allowing for realtime updates and undistortion! (And is what will allow the stabilization techniques later, stay tuned ;) )

2) Wait, does that mean I can use _any_ headset?
YOU ARE GOSH DARN RIGHT!
By editing the vertex and fragment shaders, (or heck, even the DirectX instance!) you can use _any_ headset.
Alternatively you could replace the cameras in the unity scene with any renderer, steamVR, ect. and still utilize the leapmotion MRTK integration esky provides!


Esky (With the exception of the V1 rendering integration) 
is licenced under the BSD 3 clause. While I don't really care where and how you use this software, with great power comes great responsibility. Using this software comes with one condition, that you please use the following bibtex citation:

@inproceedings{10.1145/3380867.3426220,
author = {Constantine, Rompapas Damien and Quiros, Daniel Flores and Rodda, Charlton and Brown, Bryan Christopher and Zerkin, Noah Benjamin and Cassinelli, Alvaro},
title = {Project Esky: Enabling High Fidelity Augmented Reality on an Open Source Platform},
year = {2020},
isbn = {9781450375269},
publisher = {Association for Computing Machinery},
address = {New York, NY, USA},
url = {https://doi.org/10.1145/3380867.3426220},
doi = {10.1145/3380867.3426220},
abstract = {This demonstration showcases a complete Open-Source Augmented Reality (AR) modular platform capable of high fidelity natural hand-interactions with virtual content, high field of view, and spatial mapping for environment interactions. We do this via several live desktop demonstrations. Finally, included in this demonstration is a completed open source schematic, allowing anyone interested in utilizing our proposed platform to engage with high fidelity AR. It is our hope that the work described in this demo will be a stepping stone towards bringing high-fidelity AR content to researchers and commodity users alike.},
booktitle = {Companion Proceedings of the 2020 Conference on Interactive Surfaces and Spaces},
pages = {61–63},
numpages = {3},
keywords = {open source platforms, high fidelity, augmented reality, collaborative augmented reality},
location = {Virtual Event, Portugal},
series = {ISS '20}
}


If you're looking to contribute, feel free to fork! Finally, I always welcome requests for help/collaborations, especially if you're building fun shit! Seek me out :D 
