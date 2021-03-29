# SimpleBoxModel
Simple steady-state water quality model

Calculates the outflow concentration for any number of input streams. User must supply flow rates and concentrations in input streams. Assumes the waterbody is isochoric (constant volume) and at steady-state (i.e., dCV/dt = 0).

Solves the steady-state equation
C_out = \sum(Q_in*C_in)/\sum(Q_in)

Example model for learning about water quality modeling.
