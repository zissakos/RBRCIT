(("PhysicsEngine" 
  DefManager (	
			 ("Car" ("CAR_ROOT"		 
					  SetupSpec 0
					  ))	
 
			 ("Wheel" ("CAR_WHEEL_LF"
						DoSuspensionSweep	0
						InverseMass 0.04	Radius 0.315
						DebugId			1
						IsSteered		1
						 
						WishboneLength		+0.33
						
						vecJointMount_VF	+0.38 -2.53 +0.05
						vecJointAxis_VF		+0.00 -1.00 +0.00
						vecSteeringMount_VF	+0.36 -2.65 +0.095
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	+0.30 -2.53  0.22
			
						vecStrutRodMount_SF	+0.00 	-0.12 +0.04
						vecStrutHubPoint_SF	+0.075 	+0.00 +0.11
						vecStrutHubAxis_SF	+1.00 	+0.00 +0.00
						StrutDimX		-0.09
						StrutDimZ		+0.425
						DriveAxleMountOffset	-0.05
						WishboneSign		-1.00
						SteeringSign		+1.00 

						AntiRollBarId		0
						AntiRollBarSlot		0

						vecTopMountDeformUpAxis_RF 	0.0  0.0 1.0	
						vecTopMountDeformSideAxis_RF	-1.0 0.0 0.0		
						TopMountMaxDeformSide		0.05		
						TopMountMaxDeformUp		0.05			

			
						SpringDamper ("SpringDamper"

									  InnerBumpRubberPos		0.17
									  OuterBumpRubberPos		0.41
									  DampingBumpRubber		20000
									  BumpRubberStiffness		300000

									 )
						Tyre	("Tyre"
									DebugId				0
									
									CarcassStiffnessLateral		256000.0
									CarcassStiffnessTorsional	75000.0

									ReferenceFriction		1.0

									HubOffset			0.0

									CarcassWidth			0.225
									CarcassRadius			0.305
									TreadDepth			0.01
									TreadWidth			0.20
									

									  )))
			  ("Wheel" ("CAR_WHEEL_RF"	
						InverseMass 0.04	Radius 0.315
						DebugId			2	
						IsSteered		1
						
						WishboneLength		+0.33
						
						vecJointMount_VF 	-0.38 -2.53  0.05
						vecJointAxis_VF		-0.00 -1.00 +0.00
						vecSteeringMount_VF	-0.36 -2.65 +0.095
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	-0.30 -2.52 +0.22
			
						vecStrutRodMount_SF	+0.00 +0.12 +0.04
						vecStrutHubPoint_SF	+0.075 +0.00 +0.11
						vecStrutHubAxis_SF	+1.00 +0.00 +0.00
						StrutDimX		-0.09
						StrutDimZ		+0.425
						DriveAxleMountOffset	-0.05
						WishboneSign		+1.00
						SteeringSign		-1.00
	

						AntiRollBarId		0
						AntiRollBarSlot		1

						vecTopMountDeformUpAxis_RF 	0.0  0.0 1.0	
						vecTopMountDeformSideAxis_RF	1.0 0.0 0.0		
						TopMountMaxDeformSide		0.05		
						TopMountMaxDeformUp		0.05			

			
						SpringDamper ("SpringDamper"

									  InnerBumpRubberPos		0.17
									  OuterBumpRubberPos		0.41
									  DampingBumpRubber		20000
									  BumpRubberStiffness		300000

									  )
						Tyre	("Tyre"
									DebugId				1
									
									CarcassStiffnessLateral		256000.0
									CarcassStiffnessTorsional	75000.0

									ReferenceFriction		1.0

									HubOffset			0.0

									CarcassWidth			0.225
									CarcassRadius			0.305
									TreadDepth			0.01
									TreadWidth			0.20
									
									  )))
  
			  ("Wheel" ("CAR_WHEEL_LB"	
						DoSuspensionSweep	0
						InverseMass 0.04	Radius 0.315	
						DebugId			3
						IsSteered		0
						
						WishboneLength		+0.45

						vecJointMount_VF	+0.27 +0.00 +0.055
						vecJointAxis_VF		+0.00 -1.00 +0.00
						vecSteeringMount_VF	+0.27 +0.15 +0.055
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	+0.26 +0.00 +0.19
			
						vecStrutRodMount_SF	+0.00 +0.14 +0.00
						vecStrutHubPoint_SF	+0.065 +0.00 +0.11
						vecStrutHubAxis_SF	+1.00 	+0.00 +0.00
						StrutDimX		-0.13
						StrutDimZ		+0.425
						DriveAxleMountOffset	-0.05
						WishboneSign		-1.00
						SteeringSign		-1.00 

						AntiRollBarId		1
						AntiRollBarSlot		0

						vecTopMountDeformUpAxis_RF 	0.0  0.0 1.0	
						vecTopMountDeformSideAxis_RF	-1.0 0.0 0.0		
						TopMountMaxDeformSide		0.05		
						TopMountMaxDeformUp		0.05			

			
						SpringDamper ("SpringDamper"

									  InnerBumpRubberPos		0.19
									  OuterBumpRubberPos		0.455
									  DampingBumpRubber		20000
									  BumpRubberStiffness		300000

									  )
						Tyre	("Tyre"
									DebugId				2

									CarcassStiffnessLateral		256000.0
									CarcassStiffnessTorsional	75000.0

									ReferenceFriction		1.0

									HubOffset			0.0

									CarcassWidth			0.225
									CarcassRadius			0.305
									TreadDepth			0.01
									TreadWidth			0.20
									
									  )))
			  ("Wheel" ("CAR_WHEEL_RB"	
						InverseMass 0.04	Radius 0.315
						DebugId			4	
						IsSteered		0
						
						WishboneLength		+0.45
						
						vecJointMount_VF 	-0.27 +0.00 +0.055
						vecJointAxis_VF		-0.00 -1.00 +0.00
						vecSteeringMount_VF	-0.27 +0.15 +0.055
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	-0.26 +0.00 +0.19
			
						vecStrutRodMount_SF	+0.00 -0.14 +0.00
						vecStrutHubPoint_SF	+0.065 +0.00 +0.11
						vecStrutHubAxis_SF	+1.00 +0.00 +0.00
						StrutDimX		-0.13
						StrutDimZ		+0.425
						DriveAxleMountOffset	-0.05
						WishboneSign		+1.00
						SteeringSign		+1.00

						AntiRollBarId		1
						AntiRollBarSlot		1

						vecTopMountDeformUpAxis_RF 	0.0  0.0 1.0	
						vecTopMountDeformSideAxis_RF	1.0 0.0 0.0		
						TopMountMaxDeformSide		0.05		
						TopMountMaxDeformUp		0.05			

			
						SpringDamper ("SpringDamper"

									  InnerBumpRubberPos		0.19
									  OuterBumpRubberPos		0.455
									  DampingBumpRubber		20000
									  BumpRubberStiffness		300000
									  )
						Tyre	("Tyre"
									DebugId				3
																		
									CarcassStiffnessLateral		256000.0
									CarcassStiffnessTorsional	75000.0

									ReferenceFriction		1.0

									HubOffset			0.0

									CarcassWidth			0.225
									CarcassRadius			0.305
									TreadDepth			0.01
									TreadWidth			0.20
									
									  )))
			
			  

			  
)))
