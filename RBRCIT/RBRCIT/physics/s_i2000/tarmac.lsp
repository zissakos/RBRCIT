(("PhysicsEngine" 
  DefManager (		 
			 ("Wheel" ("CAR_WHEEL_LF"
						DoSuspensionSweep	0
						InverseMass 0.04	Radius 0.315
						DebugId			1
						IsSteered		1
						 
						WishboneLength		+0.33
						
						vecJointMount_VF	+0.38 -2.55 +0.075
						vecJointAxis_VF		+0.00 -1.00 +0.00
						vecSteeringMount_VF	+0.37 -2.427 +0.080
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	+0.30 -2.53  0.22
			
						vecStrutRodMount_SF	+0.00 	+0.12 +0.015
						vecStrutHubPoint_SF	+0.075 	+0.00 +0.11
						vecStrutHubAxis_SF	+1.00 	+0.00 +0.00
						StrutDimX		-0.09
						StrutDimZ		+0.465
						DriveAxleMountOffset	-0.05
						WishboneSign		-1.00
						SteeringSign		-1.00 

						AntiRollBarId		0
						AntiRollBarSlot		0

						vecTopMountDeformUpAxis_RF 	0.0  0.0 1.0	
						vecTopMountDeformSideAxis_RF	-1.0 0.0 0.0		
						TopMountMaxDeformSide		0.05		
						TopMountMaxDeformUp		0.05
			
						SpringDamper ("SpringDamper"

									  InnerBumpRubberPos		0.12
									  OuterBumpRubberPos		0.32
									  DampingBumpRubber		20000
									  BumpRubberStiffness		500000

									 )
						Tyre	("Tyre"
									DebugId				0
									
									CarcassStiffnessLateral		410000.0
									CarcassStiffnessTorsional	80000.0

									ReferenceFriction		1.0

									HubOffset			-0.0

									CarcassWidth			0.25
									CarcassRadius			0.305
									TreadDepth			0.01
									TreadWidth			0.225
																		

									  )))
			  ("Wheel" ("CAR_WHEEL_RF"	
						InverseMass 0.04	Radius 0.315
						DebugId			2	
						IsSteered		1
						
						WishboneLength		+0.33
						
						vecJointMount_VF 	-0.38 -2.55  0.075
						vecJointAxis_VF		-0.00 -1.00 +0.00
						vecSteeringMount_VF	-0.37 -2.427 +0.080
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	-0.30 -2.52 +0.22
			
						vecStrutRodMount_SF	+0.00 -0.12 +0.015
						vecStrutHubPoint_SF	+0.075 +0.00 +0.11
						vecStrutHubAxis_SF	+1.00 +0.00 +0.00
						StrutDimX		-0.09
						StrutDimZ		+0.465
						DriveAxleMountOffset	-0.05
						WishboneSign		+1.00
						SteeringSign		+1.00
	

						AntiRollBarId		0
						AntiRollBarSlot		1

						vecTopMountDeformUpAxis_RF 	0.0  0.0 1.0	
						vecTopMountDeformSideAxis_RF	1.0 0.0 0.0		
						TopMountMaxDeformSide		0.05		
						TopMountMaxDeformUp		0.05
			
						SpringDamper ("SpringDamper"

									  InnerBumpRubberPos		0.12
									  OuterBumpRubberPos		0.32
									  DampingBumpRubber		20000
									  BumpRubberStiffness		500000

									  )
						Tyre	("Tyre"
									DebugId				1
									
									CarcassStiffnessLateral		410000.0
									CarcassStiffnessTorsional	80000.0

									ReferenceFriction		1.0

									HubOffset			-0.0

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

						vecJointMount_VF	+0.27 +0.00 +0.08
						vecJointAxis_VF		+0.00 -1.00 +0.00
						vecSteeringMount_VF	+0.27 +0.15 +0.08
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	+0.26 +0.00 +0.19
			
						vecStrutRodMount_SF	+0.00 +0.14 +0.00
						vecStrutHubPoint_SF	+0.065 +0.00 +0.11
						vecStrutHubAxis_SF	+1.00 	+0.00 +0.00
						StrutDimX		-0.13
						StrutDimZ		+0.505
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

									  InnerBumpRubberPos		0.12
									  OuterBumpRubberPos		0.355
									  DampingBumpRubber		20000
									  BumpRubberStiffness		500000

									  )
						Tyre	("Tyre"
									DebugId				2

									CarcassStiffnessLateral		410000.0
									CarcassStiffnessTorsional	80000.0

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
						
						vecJointMount_VF 	-0.27 +0.00 +0.08
						vecJointAxis_VF		-0.00 -1.00 +0.00
						vecSteeringMount_VF	-0.27 +0.15 +0.08
						vecSteeringAxis_VF	+1.00 -0.00 +0.00
						vecDriveAxleJointPos_VF	-0.26 +0.00 +0.19
			
						vecStrutRodMount_SF	+0.00 -0.14 +0.00
						vecStrutHubPoint_SF	+0.065 +0.00 +0.11
						vecStrutHubAxis_SF	+1.00 +0.00 +0.00
						StrutDimX		-0.13
						StrutDimZ		+0.505
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

									  InnerBumpRubberPos		0.12
									  OuterBumpRubberPos		0.355
									  DampingBumpRubber		20000
									  BumpRubberStiffness		500000
									  )
						Tyre	("Tyre"
									DebugId				3
																		
									CarcassStiffnessLateral		410000.0
									CarcassStiffnessTorsional	80000.0

									ReferenceFriction		1.0

									HubOffset			0.0

									CarcassWidth			0.225
									CarcassRadius			0.305
									TreadDepth			0.01
									TreadWidth			0.20
									
									  )))
			
			   
				("CarBody" ("CAR_BODY"
						  vecCenterOfGravity 0 -1.40 0.21))


			   ("Car" ("CAR_ROOT"
				
					  SetupSpec 1
					  InverseMass     0.000714
					  vecLocalInverseInertiaDiagonal 0.00076 0.00169 0.00076

					  EffWheelRadius  		0.315000
					  

					  MaxSteeringLock		2.35
					  SteeringRackRatio		+0.040
					  
					  FrontArea			2.0
					  DragCoefficient		0.4

					  SubTics	      1
					  Drive           ("Drive"
									EngineInertia		0.1
									GearBoxInertiaIn	0.1
									GearBoxInertiaOut	0.01
		
									MaxHandbrakePressure	15000000			
							
									NumberOfGears 	8						
									
									WheelInertia	2.0								
							
									   )
					ControlUnit	("ControlUnit"	
									   
									CenterDiffHandbrakeRelease 0.5
									LeftFootBrakeThreshold 0.2
									   		
									
					
									   )
						
					  iCollisionMesh	1
					  ))
)))
