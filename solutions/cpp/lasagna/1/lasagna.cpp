// ovenTime returns the amount in minutes that the lasagna should stay in the
// oven.
int ovenTime() {return 40;}

/* remainingOvenTime returns the remaining
   minutes based on the actual minutes already in the oven.
*/
int remainingOvenTime(int actualMinutesInOven) {
    
    int remainingMinutes = ovenTime() - actualMinutesInOven;
    
    return remainingMinutes;
}

/* preparationTime returns an estimate of the preparation time based on the
   number of layers and the necessary time per layer.
*/
int preparationTime(int numberOfLayers) {

    int prepTime = numberOfLayers*2;

    return prepTime;
}

// elapsedTime calculates the total time spent to create and bake the lasagna so
// far.
int elapsedTime(int numberOfLayers, int actualMinutesInOven) {

    int timeSoFar = preparationTime(numberOfLayers) + actualMinutesInOven;

    return timeSoFar;
}
